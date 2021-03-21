﻿using GovernmentSystem.Domain.Entities.CityHallEntities;

namespace GovernmentSystem.Domain.Entities
{
    public class Police
    {
        public string Identifier { get; set; }
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
