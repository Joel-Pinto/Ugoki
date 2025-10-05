using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
        {
            try
            {
                await _authService.RegisterAsync(user);
                return Ok(new
                {
                    success = true,
                    data = new { },
                    info = "User Registered with Success!" 
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    success = false,
                    data = new { },
                    info = "An error occurred while trying to register the user: " + ex.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            var response = await _authService.LoginAsync(user);
            return Ok(new
            {
                success = response.Success,
                data = new
                {
                    token = response.Token,
                    refreshToken = response.RefreshToken,
                    expiresIn = response.ExpiresMinutes
                },
                info = response.Info,
            });
        }
    }
}