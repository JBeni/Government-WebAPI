using GovernmentSystem.Domain.Entities.PoliceStations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenRecordConfiguration : IEntityTypeConfiguration<CitizenRecord>
    {
        public void Configure(EntityTypeBuilder<CitizenRecord> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Reason)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.CriminalityType)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfIssue)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Witnesses)
                .HasMaxLength(550)
                .IsRequired();
        }
    }
}
