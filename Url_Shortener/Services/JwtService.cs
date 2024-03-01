using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Url_Shortener.Authentication;
using Url_Shortener.Interfaces;
using Url_Shortener.Models;

namespace Url_Shortener.Services;

public class JwtService : IJwtService
{
    public JwtService()
    {
    }

    public IEnumerable<Claim> GetClaims(user user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.email)
        };
        return claims;
    }

    public string CreateToken(IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
            issuer: JwtOptions.ISSUER,
            audience: JwtOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(60)),
            signingCredentials: new SigningCredentials(JwtOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}