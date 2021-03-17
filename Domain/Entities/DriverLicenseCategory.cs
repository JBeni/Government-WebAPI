using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Enums;

namespace GovernmentSystem.Domain.Entities
{
    public class DriverLicenseCategory : ValidityEntity
    {
        public DriverLicenseCategories CategoryType { get; set; }
    }
}
