using GovernmentSystem.Domain.Entities.CityHallEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CityHallConfiguration : IEntityTypeConfiguration<CityHall>
    {
        public void Configure(EntityTypeBuilder<CityHall> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.CityHallName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ConstructionDate)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
