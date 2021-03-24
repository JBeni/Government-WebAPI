using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;

namespace GovernmentSystem.Application.Responses
{
    public class PoliceStationResponse : IMapFrom<PoliceStation>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PoliceStation, PoliceStationResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
