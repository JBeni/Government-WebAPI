using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.PoliceStations;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CitizenRecordResponse : IMapFrom<CitizenRecord>
    {
        public Guid Identifier { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string CriminalityType { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Witnesses { get; set; }
        public PoliceStation PoliceStation { get; set; }
        public Citizen Citizen { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CitizenRecord, CitizenRecordResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Reason, opt => opt.MapFrom(s => s.Reason))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.CriminalityType, opt => opt.MapFrom(s => s.CriminalityType))
                .ForMember(d => d.DateOfIssue, opt => opt.MapFrom(s => s.DateOfIssue))
                .ForMember(d => d.Witnesses, opt => opt.MapFrom(s => s.Witnesses))
                .ForMember(d => d.PoliceStation, opt => opt.MapFrom(s => s.PoliceStation))
                .ForMember(d => d.Citizen, opt => opt.MapFrom(s => s.Citizen));
        }
    }
}
