using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;

namespace GovernmentSystem.Domain.Entities.PoliceStations
{
    public class PolicePayment : Payment
    {
        public Invoice Invoice { get; set; }
        public PoliceStation PoliceStation { get; set; }
        public Citizen Citizen { get; set; }
    }
}
