using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentSystem.Domain.Common
{
    public class ValidityEntity : BaseEntity
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }
}
