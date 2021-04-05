using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class DriverLicense : AuditEntity
    {
        public string LicenseNumber { get; set; }
    }
}
