using Auth.NET.Libs.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.NET.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<TRole<string>>
{
    public void Configure(EntityTypeBuilder<TRole<string>> builder)
    {
        builder.ToTable("Roles");

        builder.HasIndex(r => r.Id).IsUnique();
        builder.HasIndex(r => r.Name).IsUnique();
        builder.HasIndex(r => r.Description).IsUnique();

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);
    }
}