using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CitizenEntities;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenRequestResponse : IMapFrom<CitizenRequest>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitizenRequest, CitizenRequestResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
