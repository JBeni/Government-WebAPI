using GovernmentSystem.Domain.Entities.PoliceStations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class IdentityCardAppointmentConfiguration : IEntityTypeConfiguration<IdentityCardAppointment>
    {
        public void Configure(EntityTypeBuilder<IdentityCardAppointment> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Reason)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AppointmentDay)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AdditionalInformation)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
