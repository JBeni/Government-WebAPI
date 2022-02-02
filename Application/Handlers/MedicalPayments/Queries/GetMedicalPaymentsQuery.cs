namespace GovernmentSystem.Application.Handlers.MedicalPayments.Queries
{
    public class GetMedicalPaymentsQuery : IRequest<Result<MedicalPaymentResponse>>
    {
    }

    public class GetMedicalPaymentsQueryHandler : IRequestHandler<GetMedicalPaymentsQuery, Result<MedicalPaymentResponse>>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public GetMedicalPaymentsQueryHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public Task<Result<MedicalPaymentResponse>> Handle(GetMedicalPaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentyService.GetMedicalPayments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalPaymentResponse>
                {
                    Error = $"There was an error retrieving the medical payments. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
