using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalCenterProcedure : BaseEntity
    {
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
    }
}
