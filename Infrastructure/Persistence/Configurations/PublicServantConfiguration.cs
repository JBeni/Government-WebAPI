using GovernmentSystem.Domain.Entities.PublicServantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PublicServantConfiguration : IEntityTypeConfiguration<PublicServant>
    {
        public void Configure(EntityTypeBuilder<PublicServant> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
