using GovernmentSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentSystem.Domain.Entities
{
    public class Passport : ValidityEntity
    {
        public long PassportNumber { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
    }
}
