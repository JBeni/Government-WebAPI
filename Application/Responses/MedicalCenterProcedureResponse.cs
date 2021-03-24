using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class MedicalCenterProcedureResponse : IMapFrom<MedicalCenterProcedure>
    {
        public Guid Identifier { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalCenterProcedure, MedicalCenterProcedureResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.MedicalCenter, opt => opt.MapFrom(s => s.MedicalCenter))
                .ForMember(d => d.MedicalProcedure, opt => opt.MapFrom(s => s.MedicalProcedure));
        }
    }
}
