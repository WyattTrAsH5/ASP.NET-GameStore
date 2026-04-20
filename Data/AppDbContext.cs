using Microsoft.EntityFrameworkCore;


namespace ASP.NET_GameStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
