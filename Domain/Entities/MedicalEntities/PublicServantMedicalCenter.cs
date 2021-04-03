using GovernmentSystem.Domain.Entities.PublicServantEntities;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class PublicServantMedicalCenter : PublicServant
    {
        public MedicalCenter MedicalCenter { get; set; }
    }
}
