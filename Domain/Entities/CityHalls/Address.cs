namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class Address : AuditEntity
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string Country { get; set; }

        public AddressType Type { get; set; }
    }
}
