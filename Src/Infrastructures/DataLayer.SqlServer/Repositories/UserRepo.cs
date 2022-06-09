using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.SqlServer.Common;
using DomainClass.User;

namespace DataLayer.SqlServer.Repositories
{
    public class UserRepo : EfRepository<User>
    {
        public UserRepo(ApplicationContext context) : base(context)
        {
        }
    }
}
