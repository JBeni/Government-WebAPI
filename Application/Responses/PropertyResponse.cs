using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CityHalls;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PropertyResponse : IMapFrom<Property>
    {
        public Guid Identifier { get; set; }
        public long Size { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ValueAtBuying { get; set; }
        public string CurrentValue { get; set; }
        public PropertyType Type { get; set; }
        public Address Address { get; set; }
        public CityHall CityHall { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Property, PropertyResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Size, opt => opt.MapFrom(s => s.Size))
                .ForMember(d => d.UnitOfMeasure, opt => opt.MapFrom(s => s.UnitOfMeasure))
                .ForMember(d => d.ValueAtBuying, opt => opt.MapFrom(s => s.ValueAtBuying))
                .ForMember(d => d.CurrentValue, opt => opt.MapFrom(s => s.CurrentValue))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.CityHall, opt => opt.MapFrom(s => s.CityHall));
        }
    }
}
