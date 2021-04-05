using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CityHallEntities
{
    public class CityHallReportProblem : ValidityEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
    }
}
