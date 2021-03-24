using GovernmentSystem.Domain.Entities.CityHallEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PublicServantCityHallConfiguration : IEntityTypeConfiguration<PublicServantCityHall>
    {
        public void Configure(EntityTypeBuilder<PublicServantCityHall> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
