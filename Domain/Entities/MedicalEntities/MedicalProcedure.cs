using GovernmentSystem.Domain.Common;
using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalProcedure : BaseEntity
    {
        public long Price { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureDuration { get; set; }
        public string AdditionalInformation { get; set; }

        public ICollection<MedicalCenter> MedicalCenter { get; set; }
    }
}
