namespace GovernmentSystem.Domain.Entities.Citizens
{
    public class IdentityCard : ValidityEntity
    {
        public string Series { get; set; }
        public string Type { get; set; }
    }
}
