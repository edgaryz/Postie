using Microsoft.EntityFrameworkCore;
using Postie.Core.Models;

namespace Postie.Core.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=postie_db;Integrated Security=True;TrustServerCertificate=true;");
        }
    }
}
