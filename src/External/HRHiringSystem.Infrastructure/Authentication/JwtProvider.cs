using HRHiringSystem.Application.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRHiringSystem.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expiresMinutes;
    private readonly byte[] _key;

    public JwtProvider(IOptions<JwtSettings> jwtSettingsOptions)
    {
        var jwtSettings = jwtSettingsOptions.Value;
        _issuer = jwtSettings.Issuer;
        _audience = jwtSettings.Audience;
        _expiresMinutes = jwtSettings.ExpiresMinutes;
        _key = Encoding.ASCII.GetBytes(jwtSettings.Key);
    }

    public string Generate(string userName)
    {
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, userName),
            }),
            Expires = DateTime.UtcNow.AddMinutes(_expiresMinutes),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(_key),
            SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
}

