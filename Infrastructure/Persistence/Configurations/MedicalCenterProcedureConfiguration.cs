namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class MedicalCenterProcedureConfiguration : IEntityTypeConfiguration<MedicalCenterProcedure>
    {
        public void Configure(EntityTypeBuilder<MedicalCenterProcedure> builder)
        {
            builder.HasKey(x => x.Identifier);
        }
    }
}
