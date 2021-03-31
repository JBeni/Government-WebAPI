using GovernmentSystem.Domain.Entities.CityHallEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Size)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.UnitOfMeasure)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ValueAtBuying)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.CurrentValue)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
