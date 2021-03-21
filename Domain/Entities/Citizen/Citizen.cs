﻿using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHallEntity;
using System;

namespace GovernmentSystem.Domain.Entities.Citizen
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
    }
}
