using Ugoki.Domain.Entities;
using Ugoki.Application.Models;
public interface IAuthService
{
    Task<bool> Register(UserRegisterDTO userRegisterDTO);
    Task<string?> Login(UserLoginDTO userLoginDTO);
}