using System;

namespace GovernmentSystem.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime AuditEntryCreated { get; set; }
        public string AuditEntryCreatedBy { get; set; }
        public DateTime? AuditEntryLastModified { get; set; }
        public string AuditEntryLastModifiedBy { get; set; }
    }
}
