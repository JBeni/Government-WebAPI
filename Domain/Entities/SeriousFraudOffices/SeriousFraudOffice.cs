using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHalls;
using System;

namespace GovernmentSystem.Domain.Entities.SeriousFraudOffices
{
    public class SeriousFraudOffice : AuditEntity
    {
        public string OfficeName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }
    }
}
