using Microsoft.AspNetCore.Mvc;
using Ugoki.Application.Models;

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
        public IActionResult Register([FromBody] UserRegisterDTO user)
        {
            return Ok(_authService.Register(user));
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO user)
        {
            return Ok(_authService.Login(user));
        }
    }
}