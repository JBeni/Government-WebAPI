using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenRequestResponse : IMapFrom<CitizenRequest>
    {
        public Guid Identifier { get; set; }
        public string UserCNP { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsProcessed { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitizenRequest, CitizenRequestResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.UserCNP, opt => opt.MapFrom(s => s.UserCNP))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.IsProcessed, opt => opt.MapFrom(s => s.IsProcessed));
        }
    }
}
