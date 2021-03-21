using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class DriverLicense : ValidityEntity
    {
        public string LicenseNumber { get; set; }
        public DriverLicenseCategory Category { get; set; }
    }
}
