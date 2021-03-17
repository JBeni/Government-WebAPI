using GovernmentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentSystem.Domain.Entities
{
    public class IdentityCard : ValidityEntity
    {
        public string Series { get; set; }
        public string Type { get; set; }
    }
}
