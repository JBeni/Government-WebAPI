using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.SeriousFraudOffices;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class TaxResponse : IMapFrom<Tax>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public Citizen Citizen { get; set; }
        public Company Company { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tax, TaxResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.AmountToPay, opt => opt.MapFrom(s => s.AmountToPay))
                .ForMember(d => d.AmountPaid, opt => opt.MapFrom(s => s.AmountPaid))
                .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Company))
                .ForMember(d => d.Citizen, opt => opt.MapFrom(s => s.Citizen));
        }
    }
}
