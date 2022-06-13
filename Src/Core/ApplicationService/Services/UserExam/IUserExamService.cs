using ApplicationService.Models.UserExam;

namespace ApplicationService.Services.UserExam
{
    public interface IUserExamService
    {
        DomainClass.UserExam.UserExam MakeExam(AddUserExamDto inputExam, string? currentUser);
        DomainClass.UserExam.UserExam Edit(EditUserExamDto inputExam, string? currentUser);
        List<UserExamItem> GetExam(int pageNumber, int pageSize, string? currentUser);
        bool Delete(long id, string? currentUser);
    }
}
