using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalAppointmentConfiguration : IEntityTypeConfiguration<MedicalAppointment>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointment> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Symptoms)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AppointmentDay)
                .HasMaxLength(150)
                .IsRequired();
            //builder.Property(t => t.MedicalProcedure)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.Citizen)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.PublicServantGP)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.MedicalCenter)
            //    .HasMaxLength(150)
            //    .IsRequired();
        }
    }
}
