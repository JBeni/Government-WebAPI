﻿using GovernmentSystem.Domain.Entities.CitizenEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class ReportProblemConfiguration : IEntityTypeConfiguration<ReportProblem>
    {
        public void Configure(EntityTypeBuilder<ReportProblem> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.DateOfExpiry)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
