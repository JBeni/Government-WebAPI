using GovernmentSystem.Domain.Entities.CitizenEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class DriverLicenseCategoryConfiguration : IEntityTypeConfiguration<DriverLicenseCategory>
    {
        public void Configure(EntityTypeBuilder<DriverLicenseCategory> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.CategoryType)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfIssue)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfExpiry)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
