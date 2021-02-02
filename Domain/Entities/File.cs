using GovernmentSystem.Domain.Common;

namespace GovernmentSystem.Domain.Entities
{
    public class File : AuditableEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
    }
}
