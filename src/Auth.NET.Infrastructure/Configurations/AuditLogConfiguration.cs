using Auth.NET.Libs.Domain.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.NET.Infrastructure.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<TAuditLog<string>>
{
    public void Configure(EntityTypeBuilder<TAuditLog<string>> builder)
    {
        builder.ToTable("AuditLogs");

        builder.HasOne(a => a.User)
            .WithMany(u => u.AuditLogs)
            .HasForeignKey(a => a.UserId);
    }
}