namespace GovernmentSystem.Infrastructure.Persistence.Configurations
{
    public class PropertyTypeConfiguration : IEntityTypeConfiguration<PropertyType>
    {
        public void Configure(EntityTypeBuilder<PropertyType> builder)
        {
            builder.HasKey(x => x.Identifier);

            builder.Property(t => t.Type)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
