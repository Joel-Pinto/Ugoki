using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Ugoki.Domain.Entities;
using Ugoki.Application.Common;
using Ugoki.Application.Interfaces;

namespace Ugoki.Application.Services
{
    public class TokenGenerationService : ITokenGenServices
    {
        private readonly JwtSettings _jwtOptions;

        public TokenGenerationService(IOptions<JwtSettings> options)
        {
            Console.WriteLine("TokenGenerationService constructed. Token: " + options.Value.Token);
            _jwtOptions = options.Value;
        }

        public string GenerateToken(Guid userId, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.Token);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),                // Unique identifier for my Claim
                new(JwtRegisteredClaimNames.Sub, userId.ToString()),                        // User's id
                new(JwtRegisteredClaimNames.Nickname, username),                            // User's username
                new(JwtRegisteredClaimNames.AuthTime, DateTime.UtcNow.ToString()),          // Time the token got created
                new(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddDays(1).ToString())     // Token expiration date
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
        public RefreshToken GenerateSecureRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };
        }
    }
}