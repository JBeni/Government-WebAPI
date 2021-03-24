using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class SeriousFraudOfficeResponse : IMapFrom<SeriousFraudOffice>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeriousFraudOffice, SeriousFraudOfficeResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
