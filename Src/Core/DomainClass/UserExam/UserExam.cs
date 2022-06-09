using DomainClass.Common;

namespace DomainClass.UserExam
{
    public class UserExam : BaseEntity
    {
        public string Name { get; set; }
        public User.User User { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
