using GovernmentSystem.Domain.Common;
using System;
using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class CityHall : BaseEntity
    {
        public string UniqueIdentifier { get; set; }
        public string Name { get; set; }
        public DateTime ConstructionDate { get; set; }

        public Address Address { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
