namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.CIF)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Name)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.FoundationYear)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Domain)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Status)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DeletionDate)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
