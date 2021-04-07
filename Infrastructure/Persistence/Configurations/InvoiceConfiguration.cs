using GovernmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
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
            builder.Property(t => t.IssuedDate)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DueDate)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
