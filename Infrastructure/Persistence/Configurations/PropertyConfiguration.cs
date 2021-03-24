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

            builder.Property(t => t.Address)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
