using GovernmentSystem.Domain.Entities.PoliceStations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PoliceReportProblemConfiguration : IEntityTypeConfiguration<PoliceReportProblem>
    {
        public void Configure(EntityTypeBuilder<PoliceReportProblem> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Title)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.IsProcessed)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
