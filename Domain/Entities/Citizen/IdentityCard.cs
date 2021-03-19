using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.Citizen
{
    public class IdentityCard : ValidityEntity
    {
        public string Series { get; set; }
        public string Type { get; set; }
    }
}
