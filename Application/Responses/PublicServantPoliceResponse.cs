using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.PublicServantEntities;

namespace GovernmentSystem.Application.Responses
{
    public class PublicServantPoliceResponse : IMapFrom<PublicServantPolice>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicServantPolice, PublicServantPoliceResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
