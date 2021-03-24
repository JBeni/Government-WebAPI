using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PublicServantSFOResponse : IMapFrom<PublicServantSFO>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicServantSFO, PublicServantSFOResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
