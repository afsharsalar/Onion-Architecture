using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ApplicationService.Models.User;
using DomainClass.User;

namespace ApplicationService.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public DomainClass.User.User Register(AddUserDto model)
        {
            var hashPassword = Security.SecurePasswordHasher.Hash(model.Password);
            var user = new DomainClass.User.User
            {
                Password = hashPassword,
                Mobile = model.Mobile,
                Name = model.Name
            };

            _repository.Insert(user);
            _repository.SaveChanges();
            return user;
        }
    }
}
