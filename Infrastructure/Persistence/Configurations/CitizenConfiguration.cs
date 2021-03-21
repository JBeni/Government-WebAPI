using GovernmentSystem.Domain.Entities.CitizenEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
