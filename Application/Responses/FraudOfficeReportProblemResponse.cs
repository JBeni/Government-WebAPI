﻿namespace GovernmentSystem.Application.Responses
{
    public class FraudOfficeReportProblemResponse : IMapFrom<FraudOfficeReportProblem>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public SeriousFraudOffice SeriousFraudOffice { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FraudOfficeReportProblem, FraudOfficeReportProblemResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.IsProcessed, opt => opt.MapFrom(s => s.IsProcessed))
                .ForMember(d => d.SeriousFraudOffice, opt => opt.MapFrom(s => s.SeriousFraudOffice));
        }
    }
}
