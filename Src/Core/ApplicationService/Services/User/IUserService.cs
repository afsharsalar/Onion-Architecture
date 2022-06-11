using ApplicationService.Models.User;

namespace ApplicationService.Services.User
{
    public interface IUserService
    {
        DomainClass.User.User Register(AddUserDto model);
    }
}
