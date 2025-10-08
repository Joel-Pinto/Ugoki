using Ugoki.Application.Interfaces;
using Ugoki.Domain.Entities;

namespace Ugoki.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        ArgumentNullException.ThrowIfNull(_userRepository = userRepository);
    }

    public async Task<User> GetUserAsync(string email)
    {
        return await _userRepository.GetUserByEmailAsync(email);
    } 
}
