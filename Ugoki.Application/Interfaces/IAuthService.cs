using Ugoki.Application.Common;
using Ugoki.Application.Models;
public interface IAuthService
{
    Task<RegistrationResponse> RegisterAsync(UserRegisterDTO userRegisterDTO);
    Task<LoginResponse> LoginAsync(UserLoginDTO userLoginDTO);
}