using Ugoki.Application.Models;
using Ugoki.Domain.Entities;

namespace Ugoki.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> SaveUpdateJwtToken(string token, string username);
        Task<bool> DeleteUser(int id);
    }
}