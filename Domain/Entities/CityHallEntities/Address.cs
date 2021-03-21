namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class Address
    {
        public int Id { get; set; }
        public string ZipCode { get; set; }
        public string Location { get; set; }
        public string County { get; set; }
        public string Country { get; set; }

        public AddressType Type { get; set; }
    }
}
