namespace GovernmentSystem.Application.Handlers.MedicalAppointments.Queries
{
    public class GetMedicalAppointmentsQuery : IRequest<Result<MedicalAppointmentResponse>>
    {
    }

    public class GetMedicalAppointmentsQueryHandler : IRequestHandler<GetMedicalAppointmentsQuery, Result<MedicalAppointmentResponse>>
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;

        public GetMedicalAppointmentsQueryHandler(IMedicalAppointmentService medicalAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
        }

        public Task<Result<MedicalAppointmentResponse>> Handle(GetMedicalAppointmentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalAppointmentService.GetMedicalAppointments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalAppointmentResponse>
                {
                    Error = $"There was an error retrieving the medical appointments. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
