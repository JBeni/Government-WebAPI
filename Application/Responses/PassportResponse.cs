using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PassportResponse : IMapFrom<Passport>
    {
        public Guid Identifier { get; set; }
        public long PassportNumber { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Passport, PassportResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.PassportNumber, opt => opt.MapFrom(s => s.PassportNumber))
                .ForMember(d => d.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => s.Country));
        }
    }
}
