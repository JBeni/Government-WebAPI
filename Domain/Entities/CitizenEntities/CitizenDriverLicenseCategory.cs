﻿using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class CitizenDriverLicenseCategory : ValidityEntity
    {
        public Citizen Citizen { get; set; }
        public DriverLicenseCategory DriverLicenseCategory { get; set; }
    }
}