using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.PoliceStations
{
    public class PublicServantPoliceStation : PublicServant
    {
        public PoliceStation PoliceStation { get; set; }
    }
}
