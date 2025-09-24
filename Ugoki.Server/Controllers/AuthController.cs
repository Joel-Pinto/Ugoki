using Microsoft.AspNetCore.Mvc;
using Ugoki.Domain.Entities;
using Ugoki.Application.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Ugoki.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserRegisterDTO userRegisterDTO)
        {
            User newUser = _authService.RegisterUser(userRegisterDTO);
            
            // Handle user registration
            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserLoginDTO userLoginDTO)
        {
            User user = new User();
            user.Email = "geral.joelpinto@gmail.com";
            user.FullName = "Joel Pinto";
            user.Id = 1;
            user.Username = "Fockester";

            if(!_authService.ValidateUserLogin(userLoginDTO))
            {
                return BadRequest("Password or Username is incorrect..");
            }
            
            // I Need to create and return a JWT Token
            string userToken = _authService.CreateJwtToken();
            // Handle user login
            return Ok(userToken);
        }
    }
}