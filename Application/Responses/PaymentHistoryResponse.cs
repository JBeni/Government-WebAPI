using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities;
using GovernmentSystem.Domain.Entities.Citizens;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class PaymentHistoryResponse : IMapFrom<PaymentHistory>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Citizen CitizenWhoPaid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentHistory, PaymentHistoryResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.InstitutionType, opt => opt.MapFrom(s => s.InstitutionType))
                .ForMember(d => d.AmountToPay, opt => opt.MapFrom(s => s.AmountToPay))
                .ForMember(d => d.AmountPaid, opt => opt.MapFrom(s => s.AmountPaid))
                .ForMember(d => d.DateOfPayment, opt => opt.MapFrom(s => s.DateOfPayment))
                .ForMember(d => d.CitizenWhoPaid, opt => opt.MapFrom(s => s.CitizenWhoPaid));
        }
    }
}
