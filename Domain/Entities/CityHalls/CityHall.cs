using GovernmentSystem.Domain.Common;
using System;

namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class CityHall : AuditEntity
    {
        public string CityHallName { get; set; }
        public DateTime ConstructionDate { get; set; }

        public Address Address { get; set; }
    }
}
