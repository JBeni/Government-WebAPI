using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.CityHallEntities;

namespace GovernmentSystem.Application.Responses
{
    public class CityHallResponse : IMapFrom<CityHall>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CityHall, CityHallResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
