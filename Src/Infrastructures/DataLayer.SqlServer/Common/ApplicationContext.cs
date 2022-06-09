using DomainClass.User;
using DomainClass.UserExam;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlServer.Common
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //تنظیمات موجودیت ها از همین نام اسمبلی استخراج گردد
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            //برای حالت soft Delete
            //موجودیت آزمون در صورتی که فیلد آن
            //false
            //باشد در نظر بگیر
            modelBuilder.Entity<UserExam>().HasQueryFilter(c => c.IsDeleted == false);

            //فراخوانی متد کلاس پایه
            base.OnModelCreating(modelBuilder);
        }
    }
}
