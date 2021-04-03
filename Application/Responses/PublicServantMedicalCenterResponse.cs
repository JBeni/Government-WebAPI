using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PublicServantMedicalCenterResponse : IMapFrom<PublicServantMedicalCenter>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public MedicalCenter MedicalCenter { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PublicServantMedicalCenter, PublicServantMedicalCenterResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.CNP, opt => opt.MapFrom(s => s.CNP))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.DutyRole, opt => opt.MapFrom(s => s.DutyRole))
                .ForMember(d => d.ContractYears, opt => opt.MapFrom(s => s.ContractYears))
                .ForMember(d => d.HireStartDate, opt => opt.MapFrom(s => s.HireStartDate))
                .ForMember(d => d.HireEndDate, opt => opt.MapFrom(s => s.HireEndDate))
                .ForMember(d => d.MedicalCenter, opt => opt.MapFrom(s => s.MedicalCenter));
        }
    }
}
