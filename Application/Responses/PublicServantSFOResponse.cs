using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.PublicServantEntities;

namespace GovernmentSystem.Application.Responses
{
    public class PublicServantSFOResponse : IMapFrom<PublicServantSFO>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicServantSFO, PublicServantSFOResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
