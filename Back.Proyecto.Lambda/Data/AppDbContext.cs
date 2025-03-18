using Microsoft.EntityFrameworkCore;

namespace Back.Proyecto.Lambda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}