using Ugoki.Application.Models;

namespace Ugoki.Application.Services
{
    public class AuthService
    {
        private readonly IAuthService _authService;
        public AuthService(IAuthService authService)
        {
            _authService = authService;
        }
        public async Task<string?> Login(UserLoginDTO userLoginDto)
        {
            return await _authService.Login(userLoginDto);
        }
        public Task<bool> Register(UserRegisterDTO userRegisterDTO)
        {
            return _authService.Register(userRegisterDTO); 
        }
    }
}