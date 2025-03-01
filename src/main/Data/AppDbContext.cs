using DAMBackend.Archived.ProjectArchivedModel;
using DAMBackend.Archived.UserArchivedModel;
using DAMBackend.Model.FileModel;
using DAMBackend.Model.ProjectModel;
using DAMBackend.Model.TagModel;
using DAMBackend.Model.UserModel;
using DAMBackend.Models;
using Microsoft.EntityFrameworkCore;
using File = DAMBackend.Model.FileModel;

namespace DAMBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        
        public DbSet<FileClass> Files { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
