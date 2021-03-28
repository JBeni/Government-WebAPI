using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries
{
    public class GetMedicalPaymentHistoryByIdQuery : IRequest<MedicalPaymentHistoryResponse>
    {
        public Guid Identifier { get; set; }
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
                throw new Exception("There was an error retrieving the medical payment history by Id", ex);
            }
        }
    }
}
