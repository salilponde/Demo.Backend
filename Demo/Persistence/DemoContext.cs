using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Persistence
{
    public class DemoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Demo;User Id=sa;Password=yourStrong(!)Password;Encrypt=False");
        }
    }
}
