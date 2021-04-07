using GovernmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PaymentHistoryConfiguration : IEntityTypeConfiguration<PaymentHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentHistory> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Title)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.InstitutionType)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AmountToPay)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.AmountPaid)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfPayment)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
