using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.MedicalEntities;

namespace GovernmentSystem.Application.Responses
{
    public class MedicalCenterProcedureResponse : IMapFrom<MedicalCenterProcedure>
    {
        public int Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalCenterProcedure, MedicalCenterProcedureResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
