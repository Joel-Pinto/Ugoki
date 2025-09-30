namespace Ugoki.Application.Common
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public double ExpiresMinutes { get; set; }
    }
}