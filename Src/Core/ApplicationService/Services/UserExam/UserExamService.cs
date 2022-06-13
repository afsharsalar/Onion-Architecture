using ApplicationService.Models.UserExam;
using ApplicationService.Services.User;
using DomainClass.UserExam;

namespace ApplicationService.Services.UserExam
{
    public class UserExamService : IUserExamService
    {
        private readonly IUserService _service;
        private readonly IUserExamRepository _repository;


        public UserExamService(IUserService service, IUserExamRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        public DomainClass.UserExam.UserExam MakeExam(AddUserExamDto inputExam, string? currentUser)
        {
            var entity = new DomainClass.UserExam.UserExam()
            {
                Name = inputExam.Name,
                User = _service.GetUserByMobile(currentUser),
                StartDate = inputExam.StartDate,
                EndDate = inputExam.EndDate,
            };
            _repository.Insert(entity);
            _repository.SaveChanges();
            return entity;
        }

        public DomainClass.UserExam.UserExam Edit(EditUserExamDto inputExam, string? currentUser)
        {
            var exam = _repository.Get(inputExam.Id);
            var user = _service.GetUserByMobile(currentUser);
            if (exam.User.Id == user.Id)
            {
                exam.Name = inputExam.Name;
                exam.EndDate = inputExam.EndDate;
                exam.StartDate = inputExam.StartDate;
                _repository.Update(exam);
                _repository.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
            return exam;
        }

        public List<UserExamItem> GetExam(int pageNumber, int pageSize, string? currentUser)
        {
            var user = _service.GetUserByMobile(currentUser);
            return _repository.GetQueryable().Where(p => p.User.Id == user.Id).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(o => new UserExamItem
                {
                    Id = o.Id,
                    Name = o.Name,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate
                }).ToList();
        }

        public bool Delete(long id, string? currentUser)
        {
            var exam = _repository.Get(Convert.ToInt32(id));
            var user = _service.GetUserByMobile(currentUser);
            if (exam.User.Id == user.Id)
            {
                exam.IsDeleted = true;
                _repository.Update(exam);
                _repository.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
            return true;
        }
    }
}
