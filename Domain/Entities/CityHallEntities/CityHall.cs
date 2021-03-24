using GovernmentSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class CityHall : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ConstructionDate { get; set; }

        public Address Address { get; set; }
    }
}
