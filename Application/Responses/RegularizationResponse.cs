namespace GovernmentSystem.Application.Responses
{
    public class RegularizationResponse : IMapFrom<Regularization>
    {
        public Guid Identifier { get; set; }
        public string Informations { get; set; }
        public string LawName { get; set; }
        public string ModificationRequired { get; set; }
        public string CompanyImpact { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Regularization, RegularizationResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Informations, opt => opt.MapFrom(s => s.Informations))
                .ForMember(d => d.LawName, opt => opt.MapFrom(s => s.LawName))
                .ForMember(d => d.ModificationRequired, opt => opt.MapFrom(s => s.ModificationRequired))
                .ForMember(d => d.CompanyImpact, opt => opt.MapFrom(s => s.CompanyImpact));
        }
    }
}
