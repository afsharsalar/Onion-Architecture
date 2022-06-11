using DataLayer.SqlServer.Common;
using DomainClass.UserExam;

namespace DataLayer.SqlServer.Repositories
{
    public class UserExamRepo : EfRepository<UserExam>, IUserExamRepository
    {
        public UserExamRepo(ApplicationContext context) : base(context)
        {
        }

        
    }
}
