using System.Security.Claims;
using Url_Shortener.Models;

namespace Url_Shortener.Interfaces;

public interface IJwtService
{
    IEnumerable<Claim> GetClaims(user user);
    string CreateToken(IEnumerable<Claim> claims);
}