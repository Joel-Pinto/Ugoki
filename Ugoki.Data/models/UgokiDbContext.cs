using Microsoft.EntityFrameworkCore;

namespace Ugoki.Data.Models
{
    public class UgokiDbContext : DbContext
    {
        public UgokiDbContext(DbContextOptions<UgokiDbContext> options)
            : base(options)
        {
        }
        public DbSet<User>? Users { get; set; }
    }
}