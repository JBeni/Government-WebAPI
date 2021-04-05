using GovernmentSystem.Domain.Entities.CityHalls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.ZipCode)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Street)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.County)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Country)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
