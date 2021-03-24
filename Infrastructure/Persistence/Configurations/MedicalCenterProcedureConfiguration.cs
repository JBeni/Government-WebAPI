﻿using GovernmentSystem.Domain.Entities.MedicalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalCenterProcedureConfiguration : IEntityTypeConfiguration<MedicalCenterProcedure>
    {
        public void Configure(EntityTypeBuilder<MedicalCenterProcedure> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Identifier)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
