using GovernmentSystem.Domain.Entities.Citizens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenRequestConfiguration : IEntityTypeConfiguration<CitizenRequest>
    {
        public void Configure(EntityTypeBuilder<CitizenRequest> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.UserCNP)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.UserName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Type)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.IsProcessed)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfIssue)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfExpiry)
                .HasMaxLength(150);
        }
    }
}
