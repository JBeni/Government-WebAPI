﻿using GovernmentSystem.Domain.Entities.CityHallEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Type)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
