using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalProcedureConfiguration : IEntityTypeConfiguration<MedicalProcedure>
    {
        public void Configure(EntityTypeBuilder<MedicalProcedure> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.AdditionalInformation)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
