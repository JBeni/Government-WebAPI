using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class MedicalCenterProcedure : AuditEntity
    {
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
    }
}
