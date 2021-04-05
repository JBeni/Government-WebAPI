using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class CitizenMedicalHistory : AuditEntity
    {
        public string Symptoms { get; set; }
        public string HealthProblem { get; set; }
        public DateTime DateOfDiagnostic { get; set; }
        public string Treatment { get; set; }
        public string AdditionalInformation { get; set; }

        public Citizen Citizen { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }
    }
}
