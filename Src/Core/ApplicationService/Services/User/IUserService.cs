using ApplicationService.Models.User;

namespace ApplicationService.Services.User
{
    public interface IUserService
    {
        DomainClass.User.User Register(AddUserDto model);

        DomainClass.User.User GetUserByMobile(string mobile);
        bool CanLogin(LoginUserDto loginModel);
    }
}
