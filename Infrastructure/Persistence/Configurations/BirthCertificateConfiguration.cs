namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class BirthCertificateConfiguration : IEntityTypeConfiguration<BirthCertificate>
    {
        public void Configure(EntityTypeBuilder<BirthCertificate> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.PersonalIdentificationNumber)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.LastName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.BirthDate)
                .HasMaxLength(150)
                .HasColumnType("DateTime")
                .IsRequired();
            builder.Property(t => t.BirthPlace)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Country)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Series)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Mother)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Father)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.RegistrationPlace)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.RegistrationDate)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
