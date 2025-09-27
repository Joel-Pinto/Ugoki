using Ugoki.Application.Interfaces;
using Ugoki.Application.Helper;
using Ugoki.Application.Services;
using Ugoki.Application.Models;
using Ugoki.Domain.Entities;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Ugoki.Data.Repositories
{
    public class AuthRepositorie : IAuthService
    {
        private readonly UgokiDbContext _context;
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly Helper _helper = new();
        public AuthRepositorie(
            UgokiDbContext context,
            ILogger<UserService> logger,
            IUnitOfWork unitOfWork,
            IUserRepository userRepository)
        {
            _context = context;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<bool> Register(UserRegisterDTO userRegisterDTO)
        {
            await _unitOfWork.BeginTransactionAsync();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userRegisterDTO.Username);

            if (user != null)
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

        public async Task<string?> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userLoginDTO.Username);

            if (user  == null)
                return null;


            return "";
        }
    }
}