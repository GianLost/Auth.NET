using Microsoft.EntityFrameworkCore;
using Auth.NET.Libs.Entities.Users;

namespace Auth.NET.Infrastructure.Data;

public class AuthDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
    }
}