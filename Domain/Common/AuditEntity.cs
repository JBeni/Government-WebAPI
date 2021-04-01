using System;

namespace GovernmentSystem.Domain.Common
{
    public abstract class AuditEntity : BaseEntity
    {
        public DateTime EntryCreated { get; set; }
        public string EntryCreatedBy { get; set; }
        public DateTime? EntryLastModified { get; set; }
        public string EntryLastModifiedBy { get; set; }
    }
}
