using Ugoki.Application.Interfaces;
using Ugoki.Domain.Entities;
using Ugoki.Application.Helper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ugoki.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UgokiDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            UgokiDbContext context,
            IUnitOfWork unitOfWork,
            ILogger<UserRepository> logger)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> SaveUpdateJwtToken(string token, string username)
        {
            await _unitOfWork.BeginTransactionAsync();

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return false;

            try
            {
                user.JwtToken = token;
                _context.Users.Update(user);
                await _unitOfWork.CommitAsync();

            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Error while saving new JWT Token");
                return false;
            }
            return true;
        }
        public async Task<bool> DeleteUser(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                    throw new Exception("User does not exist");

                _context.Users.Remove(user);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError(ex, "Error deleting the User with the id {id}", id);
                return false;
            }
            return true;
        }
    }
}