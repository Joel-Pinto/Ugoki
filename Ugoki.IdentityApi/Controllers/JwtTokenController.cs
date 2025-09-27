using Microsoft.AspNetCore.Mvc;
using Ugoki.Application.Models;
using Ugoki.IdentityApi.Services;

namespace Ugoki.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtTokenController : ControllerBase
    {
        private readonly TokenGenerationService _tokenGenService;
        public JwtTokenController(TokenGenerationService tokenGenService)
        {
            _tokenGenService = tokenGenService;
        }

        [HttpPost("token_generation")]
        public IActionResult TokenGenerator([FromBody] UserLoginDTO user)
        {
            var token = _tokenGenService.GenerateToken(user.Username);
            if (token != "")
                return Ok(token);
            else
                return BadRequest("Failed to generate a JWT token.");
        }
    }
}
