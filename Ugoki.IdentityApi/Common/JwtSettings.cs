namespace Ugoki.IdentityApi.Common
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = "";
        public string Audience { get; set; } = "";
        public string Token { get; set; } = "";
        public int ExpiresMinutes { get; set; } = 60;
    }
}