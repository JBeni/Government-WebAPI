using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.CitizenEntities;
using System;

namespace GovernmentSystem.Domain.Entities.MedicalEntities
{
    public class MedicalPaymentHistory : AuditEntity
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
