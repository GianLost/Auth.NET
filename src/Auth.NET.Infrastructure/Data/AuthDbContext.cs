using Microsoft.EntityFrameworkCore;
using Auth.NET.Libs.Models.Users;

namespace Auth.NET.Infrastructure.Data;

public class AuthDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TUser> Users => Set<TUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
    }
}