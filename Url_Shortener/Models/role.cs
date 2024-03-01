namespace Url_Shortener.Models;

public class role
{
    public int id { get; set; }
    public string email { get; set; }
    public List<user> users { get; set; }
    public role()
    {
        users = new List<user>();
    }
}
