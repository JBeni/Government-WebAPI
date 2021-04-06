using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;

namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class CityHallPayment : Payment
    {
        public Invoice Invoice { get; set; }
        public CityHall CityHall { get; set; }
        public Citizen Citizen { get; set; }
    }
}
