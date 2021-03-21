using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalAppointment
    {
        public int Id { get; set; }

        public Citizen Citizen { get; set; }
        public PublicServantGP PublicServantGP { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
