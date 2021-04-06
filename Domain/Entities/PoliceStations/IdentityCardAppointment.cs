using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Domain.Entities.PoliceStations
{
    public class IdentityCardAppointment : AuditEntity
    {
        public string Reason { get; set; }
        public DateTime AppointmentDay { get; set; }
        public string AdditionalInformation { get; set; }
        public Citizen Citizen { get; set; }
    }
}
