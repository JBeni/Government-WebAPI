namespace GovernmentSystem.Application.Handlers.MedicalPayments.Queries
{
    public class GetMedicalPaymentByIdQuery : IRequest<MedicalPaymentResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalPaymentByIdQueryHandler : IRequestHandler<GetMedicalPaymentByIdQuery, MedicalPaymentResponse>
    {
        private readonly IMedicalPaymentService _medicalPaymentyService;

        public GetMedicalPaymentByIdQueryHandler(IMedicalPaymentService medicalPaymentyService)
        {
            _medicalPaymentyService = medicalPaymentyService;
        }

        public Task<MedicalPaymentResponse> Handle(GetMedicalPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalPaymentyService.GetMedicalPaymentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical payment by Id", ex);
            }
        }
    }
}
