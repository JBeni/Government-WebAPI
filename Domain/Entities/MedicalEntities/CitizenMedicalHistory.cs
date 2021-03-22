using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class CitizenMedicalHistory : BaseEntity
    {
        public string UniqueIdentifier { get; set; }
        public string Symptoms { get; set; }
        public string HealthProblem { get; set; }
        public DateTime DateOfDiagnostic { get; set; }
        public string Treatment { get; set; }
        public string AdditionalInformation { get; set; }

        public Citizen Citizen { get; set; }
        public PublicServantGP PublicServantGP { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }
    }
}
