using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.Medicals;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenMedicalHistoryResponse : IMapFrom<CitizenMedicalHistory>
    {
        public Guid Identifier { get; set; }
        public string Symptoms { get; set; }
        public string HealthProblem { get; set; }
        public DateTime DateOfDiagnostic { get; set; }
        public string Treatment { get; set; }
        public string AdditionalInformation { get; set; }
        public Citizen Citizen { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitizenMedicalHistory, CitizenMedicalHistoryResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Symptoms, opt => opt.MapFrom(s => s.Symptoms))
                .ForMember(d => d.HealthProblem, opt => opt.MapFrom(s => s.HealthProblem))
                .ForMember(d => d.DateOfDiagnostic, opt => opt.MapFrom(s => s.DateOfDiagnostic))
                .ForMember(d => d.AdditionalInformation, opt => opt.MapFrom(s => s.AdditionalInformation))
                .ForMember(d => d.Citizen, opt => opt.MapFrom(s => s.Citizen))
                .ForMember(d => d.PublicServantMedicalCenter, opt => opt.MapFrom(s => s.PublicServantMedicalCenter))
                .ForMember(d => d.MedicalCenter, opt => opt.MapFrom(s => s.MedicalCenter))
                .ForMember(d => d.MedicalAppointment, opt => opt.MapFrom(s => s.MedicalAppointment));
        }
    }
}
