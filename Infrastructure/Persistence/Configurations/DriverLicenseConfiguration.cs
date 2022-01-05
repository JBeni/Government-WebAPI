namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class DriverLicenseConfiguration : IEntityTypeConfiguration<DriverLicense>
    {
        public void Configure(EntityTypeBuilder<DriverLicense> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.LicenseNumber)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
