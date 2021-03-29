using GovernmentSystem.Domain.Entities.PublicServantEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PublicServantPoliceConfiguration : IEntityTypeConfiguration<PublicServantPolice>
    {
        public void Configure(EntityTypeBuilder<PublicServantPolice> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.CNP)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.FirstName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.LastName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DutyRole)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ContractYears)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.HireStartDate)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.HireEndDate)
                .HasMaxLength(150)
                .IsRequired();

            //builder.Property(t => t.PoliceStation)
            //    .HasMaxLength(150)
            //    .IsRequired();
        }
    }
}
