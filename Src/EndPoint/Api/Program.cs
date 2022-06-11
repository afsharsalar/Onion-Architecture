using ApplicationService.Services.User;
using ApplicationService.Services.UserExam;
using DataLayer.SqlServer.Common;
using DataLayer.SqlServer.Repositories;
using DomainClass.User;
using DomainClass.UserExam;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var cnnString = builder.Configuration.GetConnectionString("AppCnn");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(cnnString));


            builder.Services.AddScoped<IUserExamService, UserExamService>();
            builder.Services.AddScoped<IUserExamRepository, UserExamRepo>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}