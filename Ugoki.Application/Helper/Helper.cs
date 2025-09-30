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
        public bool ValidatePassword(User user, string passwordToConfirm, string userStoredPassword)
        {
            PasswordHasher<User> passwordHasher = new();
            var result = passwordHasher.VerifyHashedPassword(user, userStoredPassword, passwordToConfirm);
            
            if (result == PasswordVerificationResult.Failed)
                return false;
            return true;
        }
    }
}