using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class CityReportProblem : ReportProblem
    {
        public CityHall CityHall { get; set; }
    }
}
