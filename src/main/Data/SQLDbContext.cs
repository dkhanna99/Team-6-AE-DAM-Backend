using Microsoft.EntityFrameworkCore;

namespace backend.sql

{
    public class SQLDbContext : DbContext
    {
        public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) { }

        public DbSet<ProjectModel> Projects { get; set; }

        public DbSet<FileModel> Files { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<FileModel>()
                .HasOne(f => f.Tags)
                .WithOne(t => t.File)
                .HasForeignKey<TagModel>(t => t.FileId)
                .IsRequired();

            modelBuilder.Entity<ProjectModel>()
                .HasMany(p => p.Files)
                .WithOne(f => f.Project)
                .HasForeignKey(f => f.ProjectId);
        }
    }
}

