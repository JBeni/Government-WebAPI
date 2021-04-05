using GovernmentSystem.Domain.Entities.Citizens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.PassportNumber)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Type)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Country)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfIssue)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfExpiry)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
