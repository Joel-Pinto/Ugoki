using Ugoki.Domain.Entities;

namespace Ugoki.Application.Interfaces
{
    public interface ITokenGenServices
    {
        public string GenerateToken(Guid userId, string username);
        public RefreshToken GenerateSecureRefreshToken();
    }
}