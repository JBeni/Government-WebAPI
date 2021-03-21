using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalProcedure
    {
        public ICollection<MedicalCenter> MedicalCenter { get; set; }
    }
}
