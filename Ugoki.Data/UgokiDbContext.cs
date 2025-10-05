using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ugoki.Data.Models;

namespace Ugoki.Data;

public class UgokiDbContext : IdentityDbContext<User>
{
    public UgokiDbContext(DbContextOptions<UgokiDbContext> options)
        : base(options)
    {
    }

    override protected void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<User>(entity =>
        {
            entity.ToTable(name: "Users");
            entity.HasIndex(u => u.Id).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
        });

        builder.Entity<RefreshToken>(entity =>
        {
            entity.ToTable(name: "RefreshTokens");
        });
    }
}