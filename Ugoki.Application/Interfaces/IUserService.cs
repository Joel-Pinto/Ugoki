using Ugoki.Domain.Entities;

namespace Ugoki.Application.Interfaces;

public interface IUserService
{
    Task<User> GetUserAsync(string email);
}