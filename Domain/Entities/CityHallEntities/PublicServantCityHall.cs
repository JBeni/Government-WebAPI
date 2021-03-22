using GovernmentSystem.Domain.Entities.PublicServantEntities;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class PublicServantCityHall : PublicServant
    {
        public CityHall CityHall { get; set; }
    }
}
