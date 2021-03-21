using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities.CitizenEntities
{
    public class ReportProblem : ValidityEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
    }
}
