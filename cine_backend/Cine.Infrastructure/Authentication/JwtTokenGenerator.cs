using System.Security.Claims;
using Cine.Application.Common.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Cine.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid ID, string firstname, string lastname)
    {
        var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("supersecret-key-with32-character")), 
                        SecurityAlgorithms.HmacSha256);
        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, ID.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstname),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: "Cine",
            expires: DateTime.Now.AddHours(1),
            claims: claims,
            signingCredentials: signingCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}