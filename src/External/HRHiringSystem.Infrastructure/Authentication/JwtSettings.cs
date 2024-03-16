using System.ComponentModel.DataAnnotations;

namespace HRHiringSystem.Infrastructure.Authentication;

public class JwtSettings
{
    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string Audience { get; set; } = string.Empty;

    [Required]
    public int ExpiresMinutes { get; set; }

    [Required]
    public string Key { get; set; } = string.Empty;
}

