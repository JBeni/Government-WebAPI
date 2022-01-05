namespace GovernmentSystem.Domain.Entities.SeriousFraudOffices
{
    public class Regularization : AuditEntity
    {
        public string Informations { get; set; }
        public string LawName { get; set; }
        public string ModificationRequired { get; set; }
        public string CompanyImpact { get; set; }
    }
}
