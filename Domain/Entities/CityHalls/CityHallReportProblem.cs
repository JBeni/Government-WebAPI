using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHalls
{
    public class CityHallReportProblem : ReportProblem
    {
        public CityHall CityHall { get; set; }
    }
}
