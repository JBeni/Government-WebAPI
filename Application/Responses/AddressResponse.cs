using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class AddressResponse : IMapFrom<Address>
    {
        public Guid Identifier { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public AddressType Type { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Address, AddressResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.ZipCode, opt => opt.MapFrom(s => s.ZipCode))
                .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Street))
                .ForMember(d => d.County, opt => opt.MapFrom(s => s.County))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type));
        }
    }
}
