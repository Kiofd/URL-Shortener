using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Url_Shortener.Models;

namespace Url_Shortener.Data;

public class LogginContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    private readonly IConfiguration Configuration;
    
    public LogginContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

    
}