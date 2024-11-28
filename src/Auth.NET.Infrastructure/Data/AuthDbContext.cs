using Microsoft.EntityFrameworkCore;
using Auth.NET.Libs.Entities.Users;
using Auth.NET.Libs.Entities.Auditing;
using Auth.NET.Libs.Entities.Roles;
using Auth.NET.Libs.Entities.Tokens;

namespace Auth.NET.Infrastructure.Data;

public class AuthDbContext(DbContextOptions options) : DbContext(options)
{
    // DbSets
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Token> Tokens => Set<Token>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
    }
}