using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.CityHalls;
using System;

namespace GovernmentSystem.Domain.Entities.SeriousFraudOffices
{
    public class Company : AuditEntity
    {
        public string CIF { get; set; }
        public string Name { get; set; }
        public DateTime FoundationYear { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DeletionDate { get; set; }
        public Citizen Founder { get; set; }
        public Address OfficeAddress { get; set; }
    }
}
