using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;

namespace GovernmentSystem.Application.Responses
{
    public class SeriousFraudOfficeResponse : IMapFrom<SeriousFraudOffice>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SeriousFraudOffice, SeriousFraudOfficeResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
