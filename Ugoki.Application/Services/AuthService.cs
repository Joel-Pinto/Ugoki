using Ugoki.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Ugoki.Application.Models;
using Ugoki.Application.Common;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Ugoki.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthService _authService;
        public AuthService(AuthService authService)
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