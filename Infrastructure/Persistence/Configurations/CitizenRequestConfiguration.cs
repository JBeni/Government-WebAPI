using GovernmentSystem.Domain.Entities.CitizenEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenRequestConfiguration : IEntityTypeConfiguration<CitizenRequest>
    {
        public void Configure(EntityTypeBuilder<CitizenRequest> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Identifier)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
