using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPaymentHistories.Queries
{
    public class GetMedicalPaymentHistoriesQuery : IRequest<List<MedicalPaymentHistoryResponse>>
    {
    }

    public class GetMedicalPaymentHistoriesQueryHandler : IRequestHandler<GetMedicalPaymentHistoriesQuery, List<MedicalPaymentHistoryResponse>>
    {
        private readonly IMedicalPaymentHistoryService _medicalPaymentHistoryService;

        public GetMedicalPaymentHistoriesQueryHandler(IMedicalPaymentHistoryService medicalPaymentHistoryService)
        {
            _medicalPaymentHistoryService = medicalPaymentHistoryService;
        }

        public Task<List<MedicalPaymentHistoryResponse>> Handle(GetMedicalPaymentHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentHistoryService.GetMedicalPaymentHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
