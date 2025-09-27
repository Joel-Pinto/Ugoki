namespace Ugoki.Application.Models
{
    public class UserRegisterDTO
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RepeatedEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RepeatedPassword { get; set; } = string.Empty;
        public DateTime CreatedAt { get; } = DateTime.UtcNow; 
        public DateTime UpdatedAt { get; } = DateTime.UtcNow;
    }
}