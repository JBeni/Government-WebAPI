using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CityHalls;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class AddressTypeResponse : IMapFrom<AddressType>
    {
        public Guid Identifier { get; set; }
        public string Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddressType, AddressTypeResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type));
        }
    }
}
