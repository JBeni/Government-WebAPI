using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class Citizen : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
        public Address PlaceOfBirth { get; set; }

        public IdentityCard IdentityCard { get; set; }
        public Passport Passport { get; set; }
        public DriverLicense DriverLicense { get; set; }

        public CityHall CityHallResidence { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantGP PublicServantGP { get; set; }
    }
}
