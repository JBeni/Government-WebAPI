using GovernmentSystem.Domain.Entities.PublicServantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PublicServantSFOConfiguration : IEntityTypeConfiguration<PublicServantSFO>
    {
        public void Configure(EntityTypeBuilder<PublicServantSFO> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
