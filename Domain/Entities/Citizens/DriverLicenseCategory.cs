﻿namespace GovernmentSystem.Domain.Entities.Citizens
{
    public class DriverLicenseCategory : AuditEntity
    {
        public string Category { get; set; }

        public ICollection<Citizen> Citizens { get; set; }
    }
}
