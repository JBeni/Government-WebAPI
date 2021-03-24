using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class Address : BaseEntity
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string Country { get; set; }

        public AddressType Type { get; set; }
    }
}
