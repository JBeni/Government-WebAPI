namespace GovernmentSystem.Domain.Entities
{
    public class PaymentHistory : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Citizen CitizenWhoPaid { get; set; }
    }
}
