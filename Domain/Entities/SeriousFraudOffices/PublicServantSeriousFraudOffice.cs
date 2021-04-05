using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.SeriousFraudOffices
{
    public class PublicServantSeriousFraudOffice : PublicServant
    {
        public SeriousFraudOffice SeriousFraudOffice { get; set; }
    }
}
