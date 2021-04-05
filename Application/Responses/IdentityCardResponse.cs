using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class IdentityCardResponse : IMapFrom<IdentityCard>
    {
        public Guid Identifier { get; set; }
        public string Series { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<IdentityCard, IdentityCardResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Series, opt => opt.MapFrom(s => s.Series))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type));
        }
    }
}
