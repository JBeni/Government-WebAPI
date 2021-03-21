using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalCenter
    {
        public string Identifier { get; set; }

        public ICollection<MedicalOperation> MedicalOperation { get; set; }
    }
}