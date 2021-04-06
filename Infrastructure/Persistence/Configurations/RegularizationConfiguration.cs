using GovernmentSystem.Domain.Entities.SeriousFraudOffices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class RegularizationConfiguration : IEntityTypeConfiguration<Regularization>
    {
        public void Configure(EntityTypeBuilder<Regularization> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Informations)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.LawName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ModificationRequired)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.CompanyImpact)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
