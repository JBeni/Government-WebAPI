namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class MedicalPayment : Payment
    {
        public Invoice Invoice { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public Citizen CitizenWhoBenefit { get; set; }
        public Citizen CitizenWhoPaid { get; set; }
    }
}
