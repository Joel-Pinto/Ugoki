using Ugoki.Application.Interfaces;
using Ugoki.Domain.Entities;

namespace Ugoki.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User?> GetUserByUsernameAsync(string username)
        {
            return _userRepository.GetUserByUsernameAsync(username);
        }
        public Task<bool> DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
    }
}
