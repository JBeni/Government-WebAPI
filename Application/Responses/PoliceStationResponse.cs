using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PoliceStationResponse : IMapFrom<PoliceStation>
    {
        public Guid Identifier { get; set; }
        public string StationName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }
        public CityHall CityHall { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PoliceStation, PoliceStationResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.StationName, opt => opt.MapFrom(s => s.StationName))
                .ForMember(d => d.ConstructionDate, opt => opt.MapFrom(s => s.ConstructionDate))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                .ForMember(d => d.CityHall, opt => opt.MapFrom(s => s.CityHall));
        }
    }
}
