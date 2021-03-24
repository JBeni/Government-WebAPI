using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class SeriousFraudOfficeResponse : IMapFrom<SeriousFraudOffice>
    {
        public Guid Identifier { get; set; }
        public string OfficeName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Address Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeriousFraudOffice, SeriousFraudOfficeResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.OfficeName, opt => opt.MapFrom(s => s.OfficeName))
                .ForMember(d => d.ConstructionDate, opt => opt.MapFrom(s => s.ConstructionDate))
                .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address));
        }
    }
}
