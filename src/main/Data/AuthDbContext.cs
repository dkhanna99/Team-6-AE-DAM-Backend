using Microsoft.EntityFrameworkCore;
using DAMBackend.Data;
using DAMBackend.Models;
using backend.auth;

namespace backend.auth
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
