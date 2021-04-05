using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.SeriousFraudOffices
{
    public class FraudOfficeReportProblem : ReportProblem
    {
        public SeriousFraudOffice SeriousFraudOffice { get; set; }
    }
}
