using ApplicationService.Models.User;
using ApplicationService.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/User/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AddUserDto addUser)
        {
            var user = _userService.Register(addUser);
            return StatusCode(201);
        }
    }
}
