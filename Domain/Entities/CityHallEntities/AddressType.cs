using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class AddressType : BaseEntity
    {
        public string UniqueIdentifier { get; set; }
        public string Type { get; set; }
    }
}
