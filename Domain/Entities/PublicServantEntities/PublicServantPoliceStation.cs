using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.PublicServantEntities
{
    public class PublicServantPoliceStation : PublicServant
    {
        public PoliceStation PoliceStation { get; set; }
    }
}
