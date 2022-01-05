namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class MedicalCenter : AuditEntity
    {
        public string CenterName { get; set; }
        public DateTime ConstructionDate { get; set; }

        public Address Address { get; set; }
        public ICollection<MedicalProcedure> MedicalProcedures { get; set; }
    }
}