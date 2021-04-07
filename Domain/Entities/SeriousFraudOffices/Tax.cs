using GovernmentSystem.Domain.Common;
using GovernmentSystem.Domain.Entities.Citizens;

namespace GovernmentSystem.Domain.Entities.SeriousFraudOffices
{
    public class Tax : AuditEntity
    {
        public string Title { get; set; }
        public string Description { get;set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public Citizen Citizen { get; set; }
        public Company Company { get; set; }
    }
}
