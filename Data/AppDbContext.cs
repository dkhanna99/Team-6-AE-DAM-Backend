using DAMBackend.Models;
using Microsoft.EntityFrameworkCore;
using File = DAMBackend.Models.File;

namespace DAMBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
