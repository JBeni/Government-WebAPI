using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalAppointment : AuditEntity
    {
        public string Symptoms { get; set; }
        public DateTime AppointmentDay { get; set; }

        public MedicalProcedure MedicalProcedure { get; set; }
        public Citizen Citizen { get; set; }
        public PublicServantMedicalCenter PublicServantGP { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
