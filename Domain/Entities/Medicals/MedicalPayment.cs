using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Domain.Entities.Medicals
{
    public class MedicalPayment : AuditEntity
    {
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }

        public MedicalProcedure MedicalProcedure { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public Citizen CitizenWhoBenefit { get; set; }
        public Citizen CitizenWhoPaid { get; set; }
    }
}
