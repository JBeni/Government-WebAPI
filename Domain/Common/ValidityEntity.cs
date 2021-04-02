using System;

namespace GovernmentSystem.Domain.Common
{
    public class ValidityEntity : AuditEntity
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
