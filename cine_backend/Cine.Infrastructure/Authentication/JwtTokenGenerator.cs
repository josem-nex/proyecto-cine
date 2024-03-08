using System.Security.Claims;
using Cine.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Cine.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using Cine.Domain.Entities;
namespace Cine.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(Partner Partner)
    {
        var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                        SecurityAlgorithms.HmacSha256);
        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, Partner.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, Partner.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, Partner.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}