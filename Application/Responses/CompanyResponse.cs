using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.CityHalls;
using GovernmentSystem.Domain.Entities.SeriousFraudOffices;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class CompanyResponse : IMapFrom<Company>
    {
        public Guid Identifier { get; set; }
        public string CIF { get; set; }
        public string Name { get; set; }
        public DateTime FoundationYear { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DeletionDate { get; set; }
        public Citizen Founder { get; set; }
        public Address OfficeAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Company, CompanyResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.CIF, opt => opt.MapFrom(s => s.CIF))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.FoundationYear, opt => opt.MapFrom(s => s.FoundationYear))
                .ForMember(d => d.Domain, opt => opt.MapFrom(s => s.Domain))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
                .ForMember(d => d.DeletionDate, opt => opt.MapFrom(s => s.DeletionDate))
                .ForMember(d => d.Founder, opt => opt.MapFrom(s => s.Founder))
                .ForMember(d => d.OfficeAddress, opt => opt.MapFrom(s => s.OfficeAddress));
        }
    }
}
