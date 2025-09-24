using Ugoki.Domain.Entities;

namespace Ugoki.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
    }
}