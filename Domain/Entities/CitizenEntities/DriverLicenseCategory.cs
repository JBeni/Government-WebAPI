using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Enums;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class DriverLicenseCategory : ValidityEntity
    {
        public DriverLicenseCategories CategoryType { get; set; }
    }
}
