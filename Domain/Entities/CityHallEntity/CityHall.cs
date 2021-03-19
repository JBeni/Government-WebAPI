namespace GovernmentSystem.Domain.Entities.CityHallEntity
{
    public class CityHall
    {
        public string Identifier { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
