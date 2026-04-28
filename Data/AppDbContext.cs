using ASP.NET_GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_GameStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
