namespace GovernmentSystem.Application.Handlers.MedicalAppointments.Queries
{
    public class GetMedicalAppointmentByIdQuery : IRequest<Result<MedicalAppointmentResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalAppointmentByIdQueryHandler : IRequestHandler<GetMedicalAppointmentByIdQuery, Result<MedicalAppointmentResponse>>
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;

        public GetMedicalAppointmentByIdQueryHandler(IMedicalAppointmentService medicalAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
        }

        public Task<Result<MedicalAppointmentResponse>> Handle(GetMedicalAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalAppointmentService.GetMedicalAppointmentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalAppointmentResponse>
                {
                    Error = $"There was an error retrieving the medical appointment by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
