using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalOperation
    {
        public ICollection<MedicalCenter> MedicalCenter { get; set; }
    }
}
