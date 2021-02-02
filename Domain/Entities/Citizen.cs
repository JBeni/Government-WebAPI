using GovernmentSystem.Domain.Common;
using System;

namespace GovernmentSystem.Domain.Entities
{
    public class Citizen : AuditableEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNP { get; set; }
        public string Passport { get; set; }
        public string CI { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
