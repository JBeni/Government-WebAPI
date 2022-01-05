namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class CitizenConfiguration : IEntityTypeConfiguration<Citizen>
    {
        public void Configure(EntityTypeBuilder<Citizen> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.LastName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.CNP)
                .IsFixedLength(true)
                .HasMaxLength(13)
                .IsRequired();
            builder.Property(t => t.Age)
                .HasMaxLength(5)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(t => t.Gender)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfBirth)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfDeath)
                .HasMaxLength(150);
        }
    }
}
