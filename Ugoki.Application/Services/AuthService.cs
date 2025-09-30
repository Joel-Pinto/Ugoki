using Ugoki.Application.Models;
using Ugoki.Application.Interfaces;

namespace Ugoki.Application.Services
{
    public class AuthService
    {
        private readonly IAuthService _authService;
        private readonly ITokenGenServices _tokenGenService;
        public AuthService(IAuthService authService, ITokenGenServices tokenGenServices)
        {
            _authService = authService;
            _tokenGenService = tokenGenServices;
        }
        public async Task<string?> LoginAsync(UserLoginDTO userLoginDto)
        {
            return await _authService.LoginAsync(userLoginDto);
        }
        public async Task<bool> Register(UserRegisterDTO userRegisterDTO)
        {
            return await _authService.RegisterAsync(userRegisterDTO);
        }
    }
}