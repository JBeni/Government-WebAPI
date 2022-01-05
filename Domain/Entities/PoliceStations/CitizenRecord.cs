namespace GovernmentSystem.Domain.Entities.PoliceStations
{
    public class CitizenRecord : AuditEntity
    {
        public string Reason { get; set; }
        public string Description { get; set; }
        public string CriminalityType { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Witnesses { get; set; }
        public PoliceStation PoliceStation { get; set; }
        public Citizen Citizen { get; set; }
    }
}
