using Ugoki.Domain.Entities;
using Ugoki.Application.Models;
public interface IAuthService
{
    Task<bool> RegisterAsync(UserRegisterDTO userRegisterDTO);
    Task<string?> LoginAsync(UserLoginDTO userLoginDTO);
}