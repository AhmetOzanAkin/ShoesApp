using Microsoft.EntityFrameworkCore;
using ShoesApp.Models;

namespace ShoesApp.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Info> Info { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
    }
}
