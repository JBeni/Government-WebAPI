using System;

namespace GovernmentSystem.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime DbEntryCreated { get; set; }
        public string DbEntryCreatedBy { get; set; }
        public DateTime? DbEntryLastModified { get; set; }
        public string DbEntryLastModifiedBy { get; set; }
    }
}
