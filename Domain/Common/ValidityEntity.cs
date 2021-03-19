using System;

namespace GovernmentSystem.Domain.Common
{
    public class ValidityEntity : BaseEntity
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
