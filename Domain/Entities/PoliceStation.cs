using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Domain.Entities
{
    public class PoliceStation : BaseEntity
    {
        public string StationName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }
        public CityHall CityHall { get; set; }
    }
}
