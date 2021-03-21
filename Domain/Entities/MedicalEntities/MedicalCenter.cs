using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalCenter
    {
        public string Identifier { get; set; }

        public ICollection<MedicalProcedure> MedicalOperation { get; set; }
    }
}