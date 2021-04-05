using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class PublicServantMedicalCenter : PublicServant
    {
        public MedicalCenter MedicalCenter { get; set; }
    }
}
