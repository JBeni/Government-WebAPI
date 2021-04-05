using GovernmentSystem.Domain.Common;
using System;

namespace GovernmentSystem.Domain.Entities.Citizens
{
    public class BirthCertificate : AuditEntity
    {
        public string PersonalIdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Country { get; set; }
        public string Series { get; set; }

        public string Mother { get; set; }
        public string Father { get; set; }

        public string RegistrationPlace { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
