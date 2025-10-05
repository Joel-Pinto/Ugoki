using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ugoki.Application.Interfaces;
using Ugoki.Data.Models;

namespace Ugoki.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UgokiDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    private readonly int MAX_AMOUNT_FAILED_ATTEMPTS = 4;

    public UserRepository(
        UgokiDbContext context,
        ILogger<UserRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Ugoki.Domain.Entities.User> GetUserByUsernameAsync(string username)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username) ??
            throw new Exception($"Queried username was not foud in the Database: {username}");

        return new Ugoki.Domain.Entities.User
        {
            Id = result.Id,
            Email = result.Email == null ? "" : result.Email,
            Username = result.UserName == null ? "" : result.UserName,
            PasswordHashed = result.PasswordHash == null ? "" : result.PasswordHash,
            isEmailConfirmed = result.EmailConfirmed,
            isTwoFactorEnabled = result.TwoFactorEnabled,
        };
    }

    public async Task<Ugoki.Domain.Entities.User> GetUserByIdAsync(string userId)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId) ??
            throw new Exception($"Queried user Id was not foud in the Database: {userId}");

        return new Ugoki.Domain.Entities.User
        {
            Id = result.Id,
            Email = result.Email == null ? "" : result.Email,
            Username = result.UserName == null ? "" : result.UserName,
            PasswordHashed = result.PasswordHash == null ? "" : result.PasswordHash,
            isEmailConfirmed = result.EmailConfirmed,
            isTwoFactorEnabled = result.TwoFactorEnabled,
        };
    }

    public async Task<Ugoki.Domain.Entities.User> GetUserByEmailAsync(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ??
            throw new Exception($"Queried user Email was not foud in the Database: {email}");

        return new Ugoki.Domain.Entities.User
        {
            Id = result.Id,
            Email = result.Email == null ? "" : result.Email,
            Username = result.UserName == null ? "" : result.UserName,
            PasswordHashed = result.PasswordHash == null ? "" : result.PasswordHash,
            isEmailConfirmed = result.EmailConfirmed,
            isTwoFactorEnabled = result.TwoFactorEnabled,
        };
    }

    public async Task AddUserFailedLoginAttempt(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId) ??
            throw new Exception($"Queried user Id was not foud in the Database: {userId}");

        if (user.AccessFailedCount > MAX_AMOUNT_FAILED_ATTEMPTS)
        {
            await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.LockoutEnabled, p => true)
                    .SetProperty(p => p.LockoutEnd, p => DateTime.UtcNow.AddMinutes(30)));
        }
        else
        {
            await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.AccessFailedCount, p => p.AccessFailedCount + 1));
        }
    }
    public async Task ResetUserFailedLoginAttempts(string userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId) ??
            throw new Exception($"Queried user Id was not foud in the Database: {userId}");

        await _context.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(u => u
                .SetProperty(p => p.AccessFailedCount, p => 0));
    }
    public async Task CreateNewUser(Ugoki.Domain.Entities.User user)
    {
        var newUser = new User
        {
            Id = user.Id,
            UserName = user.Username,
            NormalizedUserName = user.NormalizedUsername,
            Email = user.Email,
            NormalizedEmail = user.NormaizedEmail,
            EmailConfirmed = user.isEmailConfirmed,
            PasswordHash = user.PasswordHashed,
            TwoFactorEnabled = user.isTwoFactorEnabled,
            AccessFailedCount = user.AccessFailedCount,
            LockoutEnabled = false,
            LockoutEnd = null
        };
        await _context.Users.AddAsync(newUser);
    }
}