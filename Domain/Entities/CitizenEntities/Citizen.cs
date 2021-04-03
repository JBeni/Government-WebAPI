using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;
using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class Citizen : AuditEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public BirthCertificate BirthCertificate { get; set; }

        public IdentityCard IdentityCard { get; set; }
        public Passport Passport { get; set; }
        public DriverLicense DriverLicense { get; set; }

        public Address HomeAddress { get; set; }
        public CityHall CityHallResidence { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }

        public ICollection<DriverLicenseCategory> DriverLicenseCategories { get; set; }
    }
}
