using DataLayer.SqlServer.Common;
using DomainClass.User;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlServer.Repositories
{
    public class UserRepo : EfRepository<User>, IUserRepository
    {

        ApplicationContext _dbContext;
        public UserRepo(ApplicationContext context) : base(context)
        {
            _dbContext = context;
        }

        public User GetByMobile(string mobile)
        {
            return _dbContext.Users.SingleOrDefault(c => c.Mobile == mobile);
        }
    }
}
