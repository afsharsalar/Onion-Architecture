using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationService.Models.User;
using ApplicationService.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Route("api/User/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AddUserDto addUser)
        {
            var user = _userService.Register(addUser);
            return StatusCode(201);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginUserDto login)
        {

            if (_userService.CanLogin(login))
            {
                var tokenString = GenerateJSONWebToken(login.Mobile);
                return Ok(new { token = tokenString });
            }
            else
                return StatusCode(401);

        }


        private string GenerateJSONWebToken(string mobile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {

                new Claim(JwtRegisteredClaimNames.NameId, mobile),
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
