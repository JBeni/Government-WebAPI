﻿namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class MedicalAppointment : AuditEntity
    {
        public string Symptoms { get; set; }
        public DateTime AppointmentDay { get; set; }

        public MedicalProcedure MedicalProcedure { get; set; }
        public Citizen Citizen { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
    }
}
