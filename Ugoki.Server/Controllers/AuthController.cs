using Microsoft.AspNetCore.Mvc;
using Ugoki.Domain.Entities;
using Ugoki.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Ugoki.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User _user  = new User();

        private string HashPassword(User user, string password)
        {
            return new PasswordHasher<User>()
                .HashPassword(user, password);
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserRegisterDTO userRegisterDTO)
        {
            if(userRegisterDTO.Email != userRegisterDTO.RepeatedEmail)
                return BadRequest("Emails do not match");

            if (userRegisterDTO.Password != userRegisterDTO.RepeatedPassword)
                return BadRequest("Passwords do not match");
            
            // TODO: @Joel - I need to query the datbase to see if the username or email already exists

            _user.Username = userRegisterDTO.Username;
            _user.Email = userRegisterDTO.Email;
            _user.PasswordHashed = HashPassword(_user, userRegisterDTO.Password);
            _user.FullName = userRegisterDTO.FullName;

            // TODO: @Joel - Implement user registration in the database
            // WHO IS RESPONSIBLE FOR IT ? UGOKI.DATA maybe??
            
            // Handle user registration
            return Ok(_user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserLoginDTO userLoginDTO)
        {
            User user = new User();
            user.Email = "geral.joelpinto@gmail.com";
            user.FullName = "Joel Pinto";
            user.Id = 1;
            user.Username = "Fockester";
            user.PasswordHashed = HashPassword(user, "giratina435");

            //TODO: Joel- Instead of creating manually a user, I need to query the database
            _user = user;
            
            //I need to verify the username exists in the database
            if (userLoginDTO.Username != _user.Username ||
                new PasswordHasher<User>()
                    .VerifyHashedPassword(_user, _user.PasswordHashed, userLoginDTO.Password) != PasswordVerificationResult.Success)
                return BadRequest("Password or Username is incorrect..");

            // I Need to create and return a JWT Token
            string userToken = CreateToken(_user);
            // Handle user login
            return Ok(userToken);
        }

        private string CreateToken(User user)
        {
            // Create claims, still don't know what this is for
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Create the JWT key token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    configuration.GetValue<string>("AppSettings:Token")!)
            );

            // Create the credentials, when using the HmacSha512 algorithm for signing the key needs to have a sizze of 512 bits
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}