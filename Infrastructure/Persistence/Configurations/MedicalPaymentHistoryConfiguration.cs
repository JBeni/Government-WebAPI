using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalPaymentHistoryConfiguration : IEntityTypeConfiguration<MedicalPaymentHistory>
    {
        public void Configure(EntityTypeBuilder<MedicalPaymentHistory> builder)
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
            //builder.Property(t => t.MedicalProcedure)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.MedicalCenter)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.PublicServantGP)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.CitizenWhoBenefit)
            //    .HasMaxLength(150)
            //    .IsRequired();
            //builder.Property(t => t.CitizenWhoPaid)
            //    .HasMaxLength(150)
            //    .IsRequired();
        }
    }
}
