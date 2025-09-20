using Microsoft.AspNetCore.Mvc;
using Ugoki.Data.Models;

namespace Ugoki.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UgokiDbContext _context;

        public UserController(UgokiDbContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users?.ToList();
            return Ok(users);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _context.Users?.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

    }
}
