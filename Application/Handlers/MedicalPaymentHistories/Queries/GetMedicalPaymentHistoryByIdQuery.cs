using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries
{
    public class GetMedicalPaymentHistoryByIdQuery : IRequest<MedicalPaymentHistoryResponse>
    {
        public string County { get; set; }
    }

    public class GetMedicalPaymentHistoryByIdQueryHandler : IRequestHandler<GetMedicalPaymentHistoryByIdQuery, MedicalPaymentHistoryResponse>
    {
        private readonly IMedicalPaymentHistoryService _medicalPaymentHistoryService;

        public GetMedicalPaymentHistoryByIdQueryHandler(IMedicalPaymentHistoryService medicalPaymentHistoryService)
        {
            _medicalPaymentHistoryService = medicalPaymentHistoryService;
        }

        public Task<MedicalPaymentHistoryResponse> Handle(GetMedicalPaymentHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentHistoryService.GetMedicalPaymentHistoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class MedicalPaymentHistoryResponse : IMapFrom<MedicalPaymentHistory>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<MedicalPaymentHistory, MedicalPaymentHistoryResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
