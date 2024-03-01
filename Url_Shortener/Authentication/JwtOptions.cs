using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Url_Shortener.Authentication;

public class JwtOptions
{
    public const string ISSUER = "MyServer";
    public const string AUDIENCE = "Users";
    private const string KEY = "I_Love_you_soo_much_my_Friendo!_asdjn_lnadl";
    //public const int LIFETIME = 60; //minutes

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}