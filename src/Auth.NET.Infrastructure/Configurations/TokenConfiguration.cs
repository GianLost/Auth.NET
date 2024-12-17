using Auth.NET.Libs.Domain.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.NET.Infrastructure.Configurations;

public class TokenConfiguration : IEntityTypeConfiguration<TToken<string>>
{
    public void Configure(EntityTypeBuilder<TToken<string>> builder)
    {
        builder.ToTable("Tokens");

        builder.HasIndex(t => t.Id).IsUnique();
        builder.HasIndex(t => t.TokenValue).IsUnique();

        builder.HasOne(t => t.User)
            .WithMany(u => u.Tokens)
            .HasForeignKey(t => t.UserId);
    }
}