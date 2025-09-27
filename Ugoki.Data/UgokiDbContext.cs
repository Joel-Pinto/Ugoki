using Microsoft.EntityFrameworkCore;
using Ugoki.Domain.Entities;

namespace Ugoki.Data
{
    public class UgokiDbContext : DbContext
    {
        public UgokiDbContext(DbContextOptions<UgokiDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}