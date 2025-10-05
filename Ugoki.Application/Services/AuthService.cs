using Ugoki.Application.Models;
using Ugoki.Application.Interfaces;
using Ugoki.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Ugoki.Application.Common;

namespace Ugoki.Application.Services;

class AuthService : IAuthService
{
    private readonly IUnitOfWork _unityOfWork;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserRepository _userRepository;

    public AuthService(IUnitOfWork unityOfWork, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
    {
        ArgumentNullException.ThrowIfNull(_unityOfWork = unityOfWork);
        ArgumentNullException.ThrowIfNull(_userRepository = userRepository);
        ArgumentNullException.ThrowIfNull(_passwordHasher = passwordHasher);
    }
    private bool ValidateUserPassword(User user, string UserTypedPassword)
    {
        var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHashed, UserTypedPassword);
        return verificationResult == PasswordVerificationResult.Success;
    }

    public async Task<LoginResponse> LoginAsync(UserLoginDTO userLoginDTO)
    {
        await _unityOfWork.BeginTransactionAsync();
        try
        {
            User user = await _userRepository.GetUserByUsernameAsync(userLoginDTO.Username);
            if(user == null)
                throw new Exception("Username not found in the Database.");

            if (!ValidateUserPassword(user, userLoginDTO.Password))
            {
                await _userRepository.AddUserFailedLoginAttempt(userLoginDTO.UserId.ToString());
                throw new Exception("User password is incorrect!");
            }
            if (userLoginDTO.UserFailedLoginAttempts > 0)
                await _userRepository.ResetUserFailedLoginAttempts(userLoginDTO.UserId.ToString());

            return new LoginResponse(
                success: true,
                info: "User LoggedIn with Success!"
            );
        }
        catch(Exception ex)
        {
            await _unityOfWork.RollbackAsync();
            throw new Exception(ex.Message);
        }
    }

    public async Task RegisterAsync(UserRegisterDTO userRegisterDTO)
    {
        await _unityOfWork.BeginTransactionAsync();
        try
        {
            var userByUsername = await _userRepository.GetUserByUsernameAsync(userRegisterDTO.Username);
            if (userByUsername != null)
                throw new Exception("Username is already taken!");

            var userByEmail = await _userRepository.GetUserByEmailAsync(userRegisterDTO.Email);
            if (userByEmail != null)
                throw new Exception("Email is already taken!");

            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Username = userRegisterDTO.Username,
                NormalizedUsername = userRegisterDTO.Username.ToLower(),
                Email = userRegisterDTO.Email,
                NormaizedEmail = userRegisterDTO.Email.ToLower(),
                isEmailConfirmed = false,
                isTwoFactorEnabled = false,
                AccessFailedCount = 0
            };

            await _userRepository.CreateNewUser(newUser);
            await _unityOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            await _unityOfWork.RollbackAsync();
            throw new Exception("Error on User Registration!", ex);
        }
    }
}