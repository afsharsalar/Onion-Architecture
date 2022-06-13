using ApplicationService.Models.User;
using DomainClass.User;

namespace ApplicationService.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public DomainClass.User.User Register(AddUserDto model)
        {
            var hashPassword = Security.SecurePasswordHasher.Hash(model.Password);
            var user = new DomainClass.User.User
            {
                Password = hashPassword,
                Mobile = model.Mobile,
                Name = model.Name
            };

            _repository.Insert(user);
            _repository.SaveChanges();
            return user;
        }

        public DomainClass.User.User GetUserByMobile(string mobile)
        {
            return _repository.GetByMobile(mobile);
        }

        public bool CanLogin(LoginUserDto loginModel)
        {
            var user = _repository.GetByMobile(loginModel.Mobile);
            if (user != null)
            {
                return Security.SecurePasswordHasher.Verify(loginModel.Password, user.Password);
            }
            return false;
        }
    }
}
