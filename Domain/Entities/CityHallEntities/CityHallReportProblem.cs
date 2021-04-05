using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class CityHallReportProblem : ReportProblem
    {
        public CityHall CityHall { get; set; }
    }
}
