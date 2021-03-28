﻿using GovernmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PoliceStationConfiguration : IEntityTypeConfiguration<PoliceStation>
    {
        public void Configure(EntityTypeBuilder<PoliceStation> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.StationName)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.ConstructionDate)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Address)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.CityHall)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}