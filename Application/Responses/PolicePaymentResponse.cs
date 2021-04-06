using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.Citizens;
using GovernmentSystem.Domain.Entities.PoliceStations;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PolicePaymentResponse : IMapFrom<PolicePayment>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Invoice Invoice { get; set; }
        public PoliceStation PoliceStation { get; set; }
        public Citizen Citizen { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PolicePayment, PolicePaymentResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.AmountPaid, opt => opt.MapFrom(s => s.AmountPaid))
                .ForMember(d => d.AmountToPay, opt => opt.MapFrom(s => s.AmountToPay))
                .ForMember(d => d.DateOfPayment, opt => opt.MapFrom(s => s.DateOfPayment))
                .ForMember(d => d.Invoice, opt => opt.MapFrom(s => s.Invoice))
                .ForMember(d => d.PoliceStation, opt => opt.MapFrom(s => s.PoliceStation))
                .ForMember(d => d.Citizen, opt => opt.MapFrom(s => s.Citizen));
        }
    }
}
