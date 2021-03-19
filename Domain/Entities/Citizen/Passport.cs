using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.Citizen
{
    public class Passport : ValidityEntity
    {
        public long PassportNumber { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
    }
}
