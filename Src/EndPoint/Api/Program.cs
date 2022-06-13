using System.Text;
using ApplicationService.Models.User;
using ApplicationService.Services.User;
using ApplicationService.Services.UserExam;
using DataLayer.SqlServer.Common;
using DataLayer.SqlServer.Repositories;
using DomainClass.User;
using DomainClass.UserExam;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddFluentValidation();
            builder.Services.AddTransient<IValidator<AddUserDto>, AddUserDtoValidation>();
            builder.Services.AddTransient<IValidator<LoginUserDto>, LoginUserDtoValidation>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var cnnString = builder.Configuration.GetConnectionString("AppCnn");

            builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(cnnString));


            builder.Services.AddScoped<IUserExamService, UserExamService>();
            builder.Services.AddScoped<IUserExamRepository, UserExamRepo>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepo>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });







            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}