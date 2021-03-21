namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class CityHall
    {
        public string Identifier { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
