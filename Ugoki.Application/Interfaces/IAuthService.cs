using Ugoki.Application.Common;
using Ugoki.Application.Models;
public interface IAuthService
{
    Task RegisterAsync(UserRegisterDTO userRegisterDTO);
    Task<LoginResponse> LoginAsync(UserLoginDTO userLoginDTO);
}