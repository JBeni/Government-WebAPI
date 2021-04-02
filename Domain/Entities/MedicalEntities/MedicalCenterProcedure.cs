using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalCenterProcedure : AuditEntity
    {
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
    }
}
