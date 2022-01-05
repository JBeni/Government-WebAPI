namespace GovernmentSystem.Domain.Entities
{
    public class Invoice : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
