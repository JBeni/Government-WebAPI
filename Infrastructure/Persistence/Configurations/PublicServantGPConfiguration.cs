using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PublicServantGPConfiguration : IEntityTypeConfiguration<PublicServantGP>
    {
        public void Configure(EntityTypeBuilder<PublicServantGP> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
