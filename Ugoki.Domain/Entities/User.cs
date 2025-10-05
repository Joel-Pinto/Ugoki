namespace Ugoki.Domain.Entities;

public class User
{
    public string Id { get; set; } = string.Empty;
    public string Email { get; set; } = String.Empty;
    public string NormaizedEmail { get; set; } = String.Empty;
    public string Username { get; set; } = String.Empty;
    public string NormalizedUsername { get; set; } = String.Empty;
    public string PasswordHashed { get; set; } = String.Empty;
    public bool isEmailConfirmed { get; set; }
    public bool isTwoFactorEnabled { get; set; }
    public int AccessFailedCount { get; set; }
}