using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHalls;
using System;

namespace GovernmentSystem.Domain.Entities.PoliceStations
{
    public class PoliceStation : AuditEntity
    {
        public string StationName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }
        public CityHall CityHall { get; set; }
    }
}
