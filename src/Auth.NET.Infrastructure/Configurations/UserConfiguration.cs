using Auth.NET.Libs.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.NET.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<TUser<string>>
{
    public void Configure(EntityTypeBuilder<TUser<string>> builder)
    {
        builder.ToTable("Users");

        builder.HasIndex(u => u.Id).IsUnique();
        builder.HasIndex(u => u.Name).IsUnique();
        builder.HasIndex(u => u.Login).IsUnique();
        builder.HasIndex(u => u.PasswordHash).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.CellPhone).IsUnique();

        builder.HasMany(u => u.Tokens)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId);

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);
    }
}