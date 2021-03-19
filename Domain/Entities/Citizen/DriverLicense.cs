using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.Citizen
{
    public class DriverLicense : ValidityEntity
    {
        public string LicenseNumber { get; set; }
        public DriverLicenseCategory Category { get; set; }
    }
}
