using Ugoki.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Ugoki.Application.Models;
using Ugoki.Application.Common;

using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;

namespace Ugoki.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly User? _user;
        private readonly JwtSettings _configuration;

        public AuthService(IOptions<JwtSettings> jwtOptions)
        {
            _configuration = jwtOptions.Value;

            //TODO: @Joel - Need to query the user from the DB, if the user does not exist, meaning register or failed loggin
            //_user is set to null
        }
        private bool VerifyPassword(User user, string userTypedPassword)
        {
            if (new PasswordHasher<User>()
                    .VerifyHashedPassword(user, user.PasswordHashed, userTypedPassword) != PasswordVerificationResult.Success)
                return false;

            return true;
        }
        public string CreateJwtToken()
        {
            if (_user == null)
                throw new Exception("No user was queried from the database.. Does the User exist?");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.Username)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.Secret)
            );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        protected string HashPassword(User user, string password)
        {
            return new PasswordHasher<User>()
                .HashPassword(user, password);
        }
        public bool ValidateUserLogin(UserLoginDTO userLoginDto)
        {
            // Make sure the user is queried from the databases and it exists so that it can be used for the validation
            //and creation of the JWT token
            if (_user == null)
                return false;

            if (userLoginDto.Username != _user.Username && !VerifyPassword(_user, userLoginDto.Password))
            {
                return false;
            }

            return true;
        }

        public User RegisterUser(UserRegisterDTO userRegisterDTO)
        {   
            User user = new User();  

            user.Email = userRegisterDTO.Email;
            user.FullName = userRegisterDTO.FullName;
            user.Username = userRegisterDTO.Username;
            user.PasswordHashed = HashPassword(user, userRegisterDTO.Password);
            return user;
        }
    }
}