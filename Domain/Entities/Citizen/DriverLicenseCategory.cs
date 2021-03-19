using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Enums;

namespace GovernmentSystem.Domain.Entities.Citizen
{
    public class DriverLicenseCategory : ValidityEntity
    {
        public DriverLicenseCategories CategoryType { get; set; }
    }
}
