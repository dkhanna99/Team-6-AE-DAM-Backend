using Microsoft.EntityFrameworkCore;
using backend.auth;

namespace backend.auth
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
