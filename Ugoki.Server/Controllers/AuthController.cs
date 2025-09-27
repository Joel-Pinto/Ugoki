using Humanizer;
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
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
        {
            var success = await _authService.Register(user);
            return success ? Ok(new { success = true }) : BadRequest("Registration failed.");

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            var success = await _authService.Login(user);
            return success != null ? Ok(new { success = true }) : BadRequest("Login failed.");
        }
    }
}