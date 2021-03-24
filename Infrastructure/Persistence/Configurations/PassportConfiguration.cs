using GovernmentSystem.Domain.Entities.CitizenEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Country)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
