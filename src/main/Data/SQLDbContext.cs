// using DAMBackend.Model.FileModel;
// using DAMBackend.Model.ProjectModel;
// using DAMBackend.Model.TagModel;
// using DAMBackend.Model.UserModel;


// namespace DDbContextSQLDbContext
// {
//     public class SQLDbContext : DbContext
//     {
//         public SQLDbContext(DbContextOptions<SQLDbContext> options) : base(options) { }

//         public DbSet<Project> Projects { get; set; }

//         public DbSet<FileClass> Files { get; set; }

//         public DbSet<Tag> Tags { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder) 
//         {
//             // One to one betwen file and tag model
//             modelBuilder.Entity<FileClass>()
//                 .HasOne(f => f.Tags)
//                 .WithOne(t => t.File)
//                 .HasForeignKey<Tag>(t => t.FileId)
//                 .IsRequired();

//             // One to many from projects to files  // error, maybe foreign key not added yet?
//             modelBuilder.Entity<Project>()
//                 .HasMany(p => p.Files)
//                 .WithOne(f => f.Project)
//                 .HasForeignKey(f => f.ProjectId);

//             // many to many between projects and users // error, maybe foreign key not added yet?
//             modelBuilder.Entity<User>()
//                 .HasMany(u => u.Projects)
//                 .WithMany(p => p.Users); 

//             // one to many between user and files
//             modelBuilder.Entity<FileClass>()
//                 .HasOne(f => f.User)
//                 .WithMany(u => u.Files)
//                 .HasForeignKey(f => f.UserId)
//                 .IsRequired();

//             // generate int for userid
//             modelBuilder.Entity<User>()
//                 .Property(u => u.Id)
//                 .ValueGeneratedOnAdd();

//             // generate guid for fileid
//             modelBuilder.Entity<FileClass>()
//                 .Property(f => f.Id)
//                 .ValueGeneratedOnAdd();

//             // generate guid for projectid
//             modelBuilder.Entity<Project>()
//                 .Property(p => p.Id)
//                 .ValueGeneratedOnAdd();
            
//         }
//     }
// }

