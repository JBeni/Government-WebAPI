namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PolicePaymentConfiguration : IEntityTypeConfiguration<PolicePayment>
    {
        public void Configure(EntityTypeBuilder<PolicePayment> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Title)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AmountPaid)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AmountToPay)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfPayment)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
