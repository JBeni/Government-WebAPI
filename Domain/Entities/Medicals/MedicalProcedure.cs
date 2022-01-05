namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class MedicalProcedure : AuditEntity
    {
        public long Price { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureDuration { get; set; }
        public string AdditionalInformation { get; set; }

        public ICollection<MedicalCenter> MedicalCenter { get; set; }
    }
}
