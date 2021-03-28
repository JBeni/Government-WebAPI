using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Domain.Entities
{
    public class SeriousFraudOffice : BaseEntity
    {
        public string OfficeName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }
    }
}
