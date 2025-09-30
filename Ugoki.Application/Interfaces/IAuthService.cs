using Ugoki.Application.Common;
using Ugoki.Application.Models;
public interface IAuthService
{
    Task<bool> RegisterAsync(UserRegisterDTO userRegisterDTO);
    Task<LoginResponse?> LoginAsync(UserLoginDTO userLoginDTO);
}