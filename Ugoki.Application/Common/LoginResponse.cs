namespace Ugoki.Application.Common
{
    public class LoginResponse
    {
        public LoginResponse(bool success, string info, string? token = null, string? refreshToken = null, double? expiresMinutes = null)
        {
            Success = success;
            Info = info;
            Token = token;
            RefreshToken = refreshToken;
            ExpiresMinutes = expiresMinutes;
        }

        public bool Success { get; set; }
        public string Info { get; set; } = string.Empty;
        public string? Token { get; set; } = string.Empty;
        public string? RefreshToken { get; set; } = string.Empty;
        public double? ExpiresMinutes { get; set; }
    }
}