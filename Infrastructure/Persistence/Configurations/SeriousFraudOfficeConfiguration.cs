using GovernmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class SeriousFraudOfficeConfiguration : IEntityTypeConfiguration<SeriousFraudOffice>
    {
        public void Configure(EntityTypeBuilder<SeriousFraudOffice> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.OfficeName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ConstructionDate)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
