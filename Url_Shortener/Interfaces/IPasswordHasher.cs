namespace Url_Shortener.Interfaces;

public interface IPasswordHasher
{
    bool Verify(string passwordHash, string inputPassword);
    string Hash(string password);
}