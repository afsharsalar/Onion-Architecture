using DataLayer.SqlServer.Common;
using DomainClass.User;

namespace DataLayer.SqlServer.Repositories
{
    public class UserRepo : EfRepository<User>, IUserRepository
    {
        public UserRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
