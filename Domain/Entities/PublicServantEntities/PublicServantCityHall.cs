using GovernmentSystem.Domain.Entities.CityHallEntities;

namespace GovernmentSystem.Domain.Entities.PublicServantEntities
{
    public class PublicServantCityHall : PublicServant
    {
        public CityHall CityHall { get; set; }
    }
}
