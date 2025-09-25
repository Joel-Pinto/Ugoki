using Ugoki.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Ugoki.Application.Helper
{
    public class Helper
    {
        public string HashPassword(User user, string password)
        {
            return new PasswordHasher<User>()
                .HashPassword(user, password);
        }
    }
} 