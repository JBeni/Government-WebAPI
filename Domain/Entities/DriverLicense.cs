using GovernmentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentSystem.Domain.Entities
{
    public class DriverLicense : ValidityEntity
    {
        public string LicenseNumber { get; set; }
        public DriverLicenseCategory Category { get; set; }
    }
}
