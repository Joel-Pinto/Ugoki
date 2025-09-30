namespace Ugoki.Application.Common
{
    public class JwtSettings
    {
        public string Token { get; set; } = "";
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public int ExpiresMinutes { get; set; } = 60;
    }
}