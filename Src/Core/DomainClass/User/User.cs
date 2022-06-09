using DomainClass.Common;

namespace DomainClass.User
{
    public class User : BaseEntity
    {

        public string Mobile { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

    }
}
