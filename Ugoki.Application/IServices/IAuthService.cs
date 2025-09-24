using Ugoki.Domain.Entities;
using Ugoki.Application.Models;
public interface IAuthService
{
    string CreateJwtToken();
    User RegisterUser(UserRegisterDTO userRegisterDTO);
    bool ValidateUserLogin(UserLoginDTO userLoginDTO);
}