using GovernmentSystem.Domain.Entities.PublicServantEntities;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class PublicServantGP : PublicServant
    {
        public string UniqueIdentifier { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
