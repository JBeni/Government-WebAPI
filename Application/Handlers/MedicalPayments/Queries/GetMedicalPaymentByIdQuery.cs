namespace GovernmentSystem.Application.Handlers.MedicalPayments.Queries
{
    public class GetMedicalPaymentByIdQuery : IRequest<Result<MedicalPaymentResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalPaymentByIdQueryHandler : IRequestHandler<GetMedicalPaymentByIdQuery, Result<MedicalPaymentResponse>>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public GetMedicalPaymentByIdQueryHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public Task<Result<MedicalPaymentResponse>> Handle(GetMedicalPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentyService.GetMedicalPaymentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalPaymentResponse>
                {
                    Error = $"There was an error retrieving the medical payment by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
