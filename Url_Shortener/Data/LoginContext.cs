using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Url_Shortener.Models;

namespace Url_Shortener.Data;

public class LoginContext : DbContext
{
    public DbSet<role> Roles { get; set; }
    public DbSet<user> Users { get; set; }
    private readonly IConfiguration Configuration;
    
    public LoginContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

    
}