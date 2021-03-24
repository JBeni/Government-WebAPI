using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class MedicalAppointmentResponse : IMapFrom<MedicalAppointment>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalAppointment, MedicalAppointmentResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
