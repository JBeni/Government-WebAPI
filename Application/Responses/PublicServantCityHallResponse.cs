using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PublicServantCityHallResponse : IMapFrom<PublicServantCityHall>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicServantCityHall, PublicServantCityHallResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
