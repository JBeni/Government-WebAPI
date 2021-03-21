using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalPaymentHistory : AuditableEntity
    {
        public int ValuePaid { get; set; }

        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantGP GeneralPractitioner { get; set; }
        public Citizen CitizenWhoBenefit { get; set; }
        public Citizen CitizenWhoPaid { get; set; }
    }
}
