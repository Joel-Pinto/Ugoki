using Microsoft.AspNetCore.Mvc;
using Ugoki.Domain.Entities;
using Ugoki.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Ugoki.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User _user  = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserRegisterDTO userRegisterDTO)
        {
            // Validation of email
            if(userRegisterDTO.Email != userRegisterDTO.RepeatedEmail)
            {
                return BadRequest("Emails do not match");
            }

            if (userRegisterDTO.Password != userRegisterDTO.RepeatedPassword)
            {
                return BadRequest("Passwords do not match");
            }

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(_user, userRegisterDTO.Password);
            _user.Username = userRegisterDTO.Username;
            _user.Email = userRegisterDTO.Email;
            
            // Handle user registration
            return Ok(_user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserLoginDTO userLoginDTO)
        {
            // Handle user login
            return Ok();
        }
    }
}