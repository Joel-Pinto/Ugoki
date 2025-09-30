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
            var success = await _authService.RegisterAsync(user);
            return success ? 
                Ok(new { 
                    success = true,
                    message = "User registered with success"
                }) : 
                BadRequest(new
                {
                    success = false,
                    message = "Registration failed. User already registere"
                });

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            var success = await _authService.LoginAsync(user);
            return success != null ? 
                Ok(new
                {
                    success = true,
                    message = "Login Successfull",
                    token = success.Token,
                    refreshToken = success.RefreshToken,
                    expiresIn = success.ExpiresMinutes
                }) : 
                BadRequest(new {
                    success = false,
                    message = "Login failed. Password or Username is incorrect" 
                });
        }
    }
}