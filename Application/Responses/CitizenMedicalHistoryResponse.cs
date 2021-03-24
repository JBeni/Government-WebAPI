using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.MedicalEntities;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenMedicalHistoryResponse : IMapFrom<CitizenMedicalHistory>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitizenMedicalHistory, CitizenMedicalHistoryResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
