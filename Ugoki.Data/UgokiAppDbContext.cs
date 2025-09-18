using Microsoft.EntityFrameworkCore;
using Ugoki.Data.Models;

namespace Ugoki.Data
{
    public class UgokiAppDbContext : DbContext
    {
        public UgokiAppDbContext(DbContextOptions<UgokiAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
