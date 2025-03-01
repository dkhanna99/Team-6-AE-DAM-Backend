using Microsoft.EntityFrameworkCore;
using DAMBackend.Data;
using DAMBackend.Models;
using backend.auth;
using DAMBackend.Archived.UserArchivedModel;
using DAMBackend.Model.UserModel;

namespace backend.auth
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
