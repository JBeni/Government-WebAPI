using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class PublicServantCityHall : PublicServant
    {
        public CityHall CityHall { get; set; }
    }
}
