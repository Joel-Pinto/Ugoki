using Ugoki.Domain.Entities;

namespace Ugoki.Application.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username);
    Task<User> GetUserByIdAsync(string userId);
    Task<User> GetUserByEmailAsync(string email); 
    Task AddUserFailedLoginAttempt(string userId);
    Task ResetUserFailedLoginAttempts(string userId);
    Task CreateNewUser(User user);
}