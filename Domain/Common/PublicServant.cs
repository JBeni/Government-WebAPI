namespace GovernmentSystem.Domain.Common
{
    public class PublicServant : AuditEntity
    {
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }

        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
    }
}
