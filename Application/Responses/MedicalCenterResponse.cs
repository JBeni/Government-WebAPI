namespace GovernmentSystem.Application.Responses
{
    public class MedicalCenterResponse : IMapFrom<MedicalCenter>
    {
        public Guid Identifier { get; set; }
        public string CenterName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalCenter, MedicalCenterResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.CenterName, opt => opt.MapFrom(s => s.CenterName))
                .ForMember(d => d.ConstructionDate, opt => opt.MapFrom(s => s.ConstructionDate))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));
        }
    }
}
