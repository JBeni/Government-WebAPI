﻿namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class CityPayment : Payment
    {
        public Invoice Invoice { get; set; }
        public CityHall CityHall { get; set; }
        public Citizen Citizen { get; set; }
    }
}
