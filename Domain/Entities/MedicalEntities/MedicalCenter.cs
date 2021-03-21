﻿using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;
using System.Collections.Generic;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalCenter : BaseEntity
    {
        public string Identifier { get; set; }
        public string CenterName { get; set; }
        public DateTime ConstructionDate { get; set; }

        public Address Address { get; set; }
        public ICollection<MedicalProcedure> MedicalOperation { get; set; }
    }
}