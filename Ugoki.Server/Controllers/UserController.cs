using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ugoki.Application.Models;
using Ugoki.Domain.Entities;

namespace Ugoki.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [Authorize]
        [HttpGet("list_users")]
        public IActionResult GetUsers()
        {
            return Ok();
        }
        [HttpPost("delete_user")]
        public IActionResult DeleteUser([FromBody] User user)
        {
            return Ok();
        }
    }
}
