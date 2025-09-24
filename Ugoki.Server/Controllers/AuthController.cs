using Microsoft.AspNetCore.Mvc;
using Ugoki.Application.Models;
using Ugoki.Application.Services;
using Ugoki.Domain.Entities;

namespace Ugoki.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserService _userService;


        public AuthController(IAuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
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

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserById(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}