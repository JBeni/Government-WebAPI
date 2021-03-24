using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;

namespace GovernmentSystem.Application.Responses
{
    public class MedicalPaymentHistoryResponse : IMapFrom<MedicalPaymentHistory>
    {
        public Guid Identifier { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicalPaymentHistory, MedicalPaymentHistoryResponse>()
                .ForMember(d => d.Identifier, opt => opt.MapFrom(s => s.Identifier));
        }
    }
}
