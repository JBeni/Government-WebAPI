using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class CitizenRequest : ValidityEntity
    {
        public string UserCNP { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsProcessed { get; set; }
    }
}
