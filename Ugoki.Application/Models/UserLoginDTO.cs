namespace Ugoki.Application.Models
{
    public class UserLoginDTO
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}