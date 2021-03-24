using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CityHallResponse : IMapFrom<CityHall>
    {
        public Guid Identifier { get; set; }
        public string CityHallName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CityHall, CityHallResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.CityHallName, opt => opt.MapFrom(s => s.CityHallName))
                .ForMember(d => d.ConstructionDate, opt => opt.MapFrom(s => s.ConstructionDate))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));
        }
    }
}
