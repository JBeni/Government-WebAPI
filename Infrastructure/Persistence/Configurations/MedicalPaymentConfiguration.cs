using GovernmentSystem.Domain.Entities.Medicals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalPaymentConfiguration : IEntityTypeConfiguration<MedicalPayment>
    {
        public void Configure(EntityTypeBuilder<MedicalPayment> builder)
        {
            builder.HasKey(x => x.Identifier);

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
