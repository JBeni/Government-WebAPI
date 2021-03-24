using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PublicServantPoliceResponse : IMapFrom<PublicServantPolice>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicServantPolice, PublicServantPoliceResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
