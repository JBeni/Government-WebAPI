namespace GovernmentSystem.Domain.Entities.Citizens
{
    public class CitizenRequest : ValidityEntity
    {
        public string UserCNP { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsProcessed { get; set; }
    }
}
