using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class Property : BaseEntity
    {
        public long Size { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ValueAtBuying { get; set; }
        public string CurrentValue { get; set; }

        public PropertyType Type { get; set; }
        public Address Address { get; set; }
        public CityHall CityHall { get; set; }
    }
}
