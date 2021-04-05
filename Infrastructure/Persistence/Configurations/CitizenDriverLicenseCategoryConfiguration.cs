using GovernmentSystem.Domain.Entities.Citizens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenDriverLicenseCategoryConfiguration : IEntityTypeConfiguration<CitizenDriverLicenseCategory>
    {
        public void Configure(EntityTypeBuilder<CitizenDriverLicenseCategory> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.DateOfIssue)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfExpiry)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
