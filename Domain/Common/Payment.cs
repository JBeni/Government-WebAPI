using System;

namespace GovernmentSystem.Domain.Common
{
    public class Payment : AuditEntity
    {
        public string Title { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
    }
}
