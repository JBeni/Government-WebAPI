﻿namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class IdentityCardConfiguration : IEntityTypeConfiguration<IdentityCard>
    {
        public void Configure(EntityTypeBuilder<IdentityCard> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Series)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Type)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfIssue)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.DateOfExpiry)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
