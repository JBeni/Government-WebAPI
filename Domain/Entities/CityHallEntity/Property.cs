namespace GovernmentSystem.Domain.Entities.CityHallEntity
{
    public class Property
    {
        public string Identifier { get; set; }
        public long Size { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ValueAtBuying { get; set; }

        public PropertyType Type { get; set; }
        public Address Address { get; set; }
        public CityHall CityHall { get; set; }
    }
}
