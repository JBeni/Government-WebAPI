namespace GovernmentSystem.Application.Handlers.Appointments.Commands
{
    public class CreateMedicalAppointmentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Symptoms { get; set; }
        public DateTime AppointmentDay { get; set; }
        public Guid MedicalProcedureId { get; set; }
        public Guid CitizenId { get; set; }
        public Guid PublicServantMedicalCenterId { get; set; }
        public Guid MedicalCenterId { get; set; }
    }

    public class CreateMedicalAppointmentCommandHandler : IRequestHandler<CreateMedicalAppointmentCommand, RequestResponse>
    {
        private readonly IMedicalAppointmentService _appointmentService;

        public CreateMedicalAppointmentCommandHandler(IMedicalAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<RequestResponse> Handle(CreateMedicalAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _appointmentService.CreateMedicalAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateMedicalAppointmentCommandValidator : AbstractValidator<CreateMedicalAppointmentCommand>
    {
        public CreateMedicalAppointmentCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Symptoms).NotEmpty().NotNull();
            RuleFor(v => v.AppointmentDay).NotEmpty().NotNull();
            RuleFor(v => v.MedicalProcedureId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantMedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
        }
    }
}
