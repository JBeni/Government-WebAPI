namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class FraudOfficeReportProblemConfiguration : IEntityTypeConfiguration<FraudOfficeReportProblem>
    {
        public void Configure(EntityTypeBuilder<FraudOfficeReportProblem> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Title)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(150)
                .IsRequired();
            builder.Property(t => t.IsProcessed)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
