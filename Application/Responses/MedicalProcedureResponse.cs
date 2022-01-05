namespace GovernmentSystem.Application.Responses
{
    public class MedicalProcedureResponse : IMapFrom<MedicalProcedure>
    {
        public Guid Identifier { get; set; }
        public long Price { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureDuration { get; set; }
        public string AdditionalInformation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalProcedure, MedicalProcedureResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(d => d.ProcedureName, opt => opt.MapFrom(s => s.ProcedureName))
                .ForMember(d => d.ProcedureDuration, opt => opt.MapFrom(s => s.ProcedureDuration))
                .ForMember(d => d.AdditionalInformation, opt => opt.MapFrom(s => s.AdditionalInformation));
        }
    }
}
