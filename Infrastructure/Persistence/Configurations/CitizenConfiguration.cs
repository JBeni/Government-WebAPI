using GovernmentSystem.Domain.Entities.CitizenEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.LastName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.CNP)
                .IsFixedLength(true)
                .HasMaxLength(13)
                .IsRequired();
            builder.Property(t => t.Age)
                .HasMaxLength(5)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(t => t.Gender)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfBirth)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfDeath)
                .HasMaxLength(150);

            builder.Property(t => t.BirthCertificate)
                .IsRequired();
            builder.Property(t => t.IdentityCard)
                .HasMaxLength(150);
            builder.Property(t => t.Passport)
                .HasMaxLength(150);
            builder.Property(t => t.DriverLicense)
                .HasMaxLength(150);

            builder.Property(t => t.HomeAddress)
                .IsRequired();
            builder.Property(t => t.CityHallResidence)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.MedicalCenter)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.PublicServantGP)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
