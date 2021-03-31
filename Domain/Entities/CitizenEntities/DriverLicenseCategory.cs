using GovernmentSystem.Domain.Common;
using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class DriverLicenseCategory : BaseEntity
    {
        public string Category { get; set; }

        public ICollection<Citizen> Citizens { get; set; }
    }
}
