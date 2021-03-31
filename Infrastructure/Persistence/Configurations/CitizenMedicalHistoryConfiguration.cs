using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenMedicalHistoryConfiguration : IEntityTypeConfiguration<CitizenMedicalHistory>
    {
        public void Configure(EntityTypeBuilder<CitizenMedicalHistory> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Symptoms)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.HealthProblem)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfDiagnostic)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Treatment)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AdditionalInformation)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
