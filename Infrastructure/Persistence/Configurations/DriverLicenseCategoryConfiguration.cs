﻿namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class DriverLicenseCategoryConfiguration : IEntityTypeConfiguration<DriverLicenseCategory>
    {
        public void Configure(EntityTypeBuilder<DriverLicenseCategory> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Category)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
