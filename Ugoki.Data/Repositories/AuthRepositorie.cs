using Ugoki.Application.Interfaces;
using Ugoki.Application.Helper;
using Ugoki.Application.Common;
using Ugoki.Application.Models;
using Ugoki.Domain.Entities;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Ugoki.Data.Repositories
{
    public class AuthRepositorie : IAuthService
    {
        private readonly UgokiDbContext _context;
        private readonly ILogger<AuthRepositorie> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenServices _tokenGenService;
        private readonly Helper _helper = new();
        public AuthRepositorie(
            UgokiDbContext context,
            ILogger<AuthRepositorie> logger,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ITokenGenServices tokenGenServices)
        {
            _context = context;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _tokenGenService = tokenGenServices;
        }
        public async Task<bool> RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            await _unitOfWork.BeginTransactionAsync();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userRegisterDTO.Username);
            var emailVerification = await _context.Users.FirstOrDefaultAsync(u => u.Email == userRegisterDTO.Email);

            if (user != null || emailVerification != null)
                return false;

            User newUser = new User
            {
                Username = userRegisterDTO.Username,
                Email = userRegisterDTO.Email,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            };

            newUser.PasswordHashed = _helper.HashPassword(newUser, userRegisterDTO.Password);

            try
            {
                _context.Users.Add(newUser);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("There was an issue regestring the user {Username}: {Message} \n {StackTrace}", newUser.Username, ex.Message, ex.StackTrace);
                return false;
            }

            return true;
        }

        public async Task<LoginResponse?> LoginAsync(UserLoginDTO userLoginDTO)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userLoginDTO.Username);

                if (user == null)
                    return null;
                
                
                RefreshToken? refreshToken = await _context.RefreshTokens
                    .Where(rt => rt.UserId == user.Id && rt.RevokedAt == null)
                    .FirstOrDefaultAsync();


                if (refreshToken == null || refreshToken.RevokedAt != null)
                {
                    refreshToken = _tokenGenService.GenerateSecureRefreshToken();
                    refreshToken.UserId = user.Id;
                    _context.RefreshTokens.Add(refreshToken);
                }
                else if (DateTime.Compare(DateTime.UtcNow, refreshToken.ExpiresAt) > 0)
                {
                    refreshToken = _tokenGenService.GenerateSecureRefreshToken();
                    refreshToken.UserId = user.Id;
                    _context.RefreshTokens.Update(refreshToken);
                }

                if (!_helper.ValidatePassword(user, userLoginDTO.Password, user.PasswordHashed))
                    return null;

                var token = _tokenGenService.GenerateToken(user.Id, user.Username);

                await _unitOfWork.CommitAsync();

                return new LoginResponse
                {
                    Token = token,
                    RefreshToken = refreshToken.Token,
                    ExpiresMinutes = DateTime.UtcNow.Subtract(refreshToken.ExpiresAt).TotalSeconds
                };
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                _logger.LogError("There was an issue with the Login Auth method {Username}: {Message} \n {StackTrace}", userLoginDTO.Username, ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}