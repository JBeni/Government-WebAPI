using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.MedicalPayments.Queries
{
    public class GetMedicalPaymentsQuery : IRequest<List<MedicalPaymentResponse>>
    {
    }

    public class GetMedicalPaymentsQueryHandler : IRequestHandler<GetMedicalPaymentsQuery, List<MedicalPaymentResponse>>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public GetMedicalPaymentsQueryHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public Task<List<MedicalPaymentResponse>> Handle(GetMedicalPaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentyService.GetMedicalPayments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical payments", ex);
            }
        }
    }
}
