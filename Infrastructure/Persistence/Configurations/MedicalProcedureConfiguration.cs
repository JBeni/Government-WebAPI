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

            builder.Property(t => t.Price)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ProcedureName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ProcedureDuration)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AdditionalInformation)
                .HasMaxLength(150)
                .IsRequired();
            //builder.Property(t => t.MedicalCenter)
            //    .HasMaxLength(150)
            //    .IsRequired();
        }
    }
}
