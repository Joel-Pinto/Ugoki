using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ugoki.Application.Interfaces;
using Ugoki.Application.Models;
using Ugoki.Data.Models;

namespace Ugoki.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;

    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    public AuthController(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        ILogger<AuthController> logger,
        IUserService userService,
        IUnitOfWork unitOfWork)

    {
        ArgumentNullException.ThrowIfNull(_signInManager = signInManager);
        ArgumentNullException.ThrowIfNull(_userService = userService);
        ArgumentNullException.ThrowIfNull(_userManager = userManager);
        ArgumentNullException.ThrowIfNull(_unitOfWork = unitOfWork);
        ArgumentNullException.ThrowIfNull(_logger = logger);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDTO user)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var newUser = new IdentityUser();
            newUser.Email = user.Email;
            newUser.UserName = user.Username;
            newUser.NormalizedEmail = user.Email.ToLower();
            newUser.NormalizedUserName = user.Username.ToLower();
            newUser.LockoutEnabled = false;
            newUser.AccessFailedCount = 0;
            newUser.EmailConfirmed = false;
            newUser.PhoneNumberConfirmed = false;
            newUser.TwoFactorEnabled = false;

            var result = await _userManager.CreateAsync(newUser, user.Password);

            if (result.Succeeded)
            {
                _logger.Log(LogLevel.Information, $"User registered successfully {user.Username}");
            }
            else
            {
                return BadRequest(result.Errors.ToArray());
            }

            await _unitOfWork.CommitAsync();
            return Ok(new
            {
                success = true
            });
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            return Unauthorized($"Invalid {ex.Message}");
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO userDetails)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var user = await _userManager.FindByEmailAsync(userDetails.Email);
            if (user == null || user.UserName == null)
                throw new Exception("User does not exist.");

            if(user.AccessFailedCount > 4)
            {
                //TODO: Go to the user service to lockout logic
                throw new Exception("Failed to many loggin attempts, you're account has been locked off");
            }
            
            var result = await _signInManager.PasswordSignInAsync(user.UserName, userDetails.Password, isPersistent: true, lockoutOnFailure: false);
            
            if (!result.Succeeded)
            {
                //TODO: Go to user service to increment one to the failed attempts
                throw new Exception("Password is incorrect.");
            }

            _logger.LogInformation($"User with email: {userDetails.Email} just logged in with Success");

            return Ok(new
            {
                success = true
            });
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();
            return Unauthorized($"Invalid Credentials: {ex.Message}");
        }
    }
}