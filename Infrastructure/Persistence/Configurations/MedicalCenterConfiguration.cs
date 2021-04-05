using GovernmentSystem.Domain.Entities.Medicals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalCenterConfiguration : IEntityTypeConfiguration<MedicalCenter>
    {
        public void Configure(EntityTypeBuilder<MedicalCenter> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.CenterName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ConstructionDate)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
