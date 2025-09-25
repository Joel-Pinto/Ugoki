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
            //Call Apllication for User Registration 

            // Handle user registration
            return Ok($"User {userRegisterDTO.Username}, registered with Success.");
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserLoginDTO userLoginDTO)
        {
            //Call Application for User Login

            // Handle user login
            return Ok($"User {userLoginDTO.Username}, logged in with success.");
        }
    }
}