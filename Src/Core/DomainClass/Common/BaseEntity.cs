using System.ComponentModel.DataAnnotations;

namespace DomainClass.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            ModifiedOn=DateTime.UtcNow;
        }

        [Key]
        public long Id { get; set; }


        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; }


    }
}
