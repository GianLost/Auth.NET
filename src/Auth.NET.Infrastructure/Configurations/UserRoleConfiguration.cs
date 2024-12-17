using Auth.NET.Libs.Domain.Roles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.NET.Infrastructure.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<TUserRole<string>>
{
    public void Configure(EntityTypeBuilder<TUserRole<string>> builder)
    {
        builder.ToTable("UserRoles");

        builder.HasIndex(ur => ur.Id).IsUnique();

        builder.HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        builder.HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}