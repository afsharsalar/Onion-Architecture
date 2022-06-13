using DomainClass.Common;

namespace DomainClass.User
{
    public interface IUserRepository : IRepository<User>
    {

        User GetByMobile(string mobile);
    }
}
