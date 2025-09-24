using Ugoki.Application.Interfaces;
using Ugoki.Domain.Entities;
using Ugoki.Data;
using Microsoft.EntityFrameworkCore;

namespace Ugoki.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UgokiDbContext _context;

        public UserRepository(UgokiDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}