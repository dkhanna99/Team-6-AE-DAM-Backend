using DAMBackend.Models;
using Microsoft.EntityFrameworkCore;
using File = DAMBackend.Models.File;

namespace DAMBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }

        public DbSet<TagModel> Tags { get; set; }
    }
}
