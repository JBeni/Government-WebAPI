using GovernmentSystem.Domain.Entities.CityHallEntity;

namespace GovernmentSystem.Domain.Entities.PublicServant
{
    public class PublicServantCityHall : PublicServant
    {
        public CityHall CityHall { get; set; }
    }
}
