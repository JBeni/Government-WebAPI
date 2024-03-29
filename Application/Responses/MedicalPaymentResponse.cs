﻿namespace GovernmentSystem.Application.Responses
{
    public class MedicalPaymentResponse : IMapFrom<MedicalPayment>
    {
        public Guid Identifier { get; set; }
        public long AmountPaid { get; set; }
        public long AmountToPay { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Invoice Invoice { get; set; }
        public MedicalProcedure MedicalProcedure { get; set; }
        public MedicalCenter MedicalCenter { get; set; }
        public PublicServantMedicalCenter PublicServantMedicalCenter { get; set; }
        public Citizen CitizenWhoBenefit { get; set; }
        public Citizen CitizenWhoPaid { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalPayment, MedicalPaymentResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.AmountPaid, opt => opt.MapFrom(s => s.AmountPaid))
                .ForMember(d => d.AmountToPay, opt => opt.MapFrom(s => s.AmountToPay))
                .ForMember(d => d.DateOfPayment, opt => opt.MapFrom(s => s.DateOfPayment))
                .ForMember(d => d.Invoice, opt => opt.MapFrom(s => s.Invoice))
                .ForMember(d => d.MedicalProcedure, opt => opt.MapFrom(s => s.MedicalProcedure))
                .ForMember(d => d.MedicalCenter, opt => opt.MapFrom(s => s.MedicalCenter))
                .ForMember(d => d.PublicServantMedicalCenter, opt => opt.MapFrom(s => s.PublicServantMedicalCenter))
                .ForMember(d => d.CitizenWhoBenefit, opt => opt.MapFrom(s => s.CitizenWhoBenefit))
                .ForMember(d => d.CitizenWhoPaid, opt => opt.MapFrom(s => s.CitizenWhoPaid));
        }
    }
}
