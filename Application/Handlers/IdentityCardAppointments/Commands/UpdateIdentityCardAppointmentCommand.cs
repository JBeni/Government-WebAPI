namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Commands
{
    public class UpdateIdentityCardAppointmentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Reason { get; set; }
        public DateTime AppointmentDay { get; set; }
        public string AdditionalInformation { get; set; }
        public Guid CitizenId { get; set; }
    }

    public class UpdateIdentityCardAppointmentCommandHandler : IRequestHandler<UpdateIdentityCardAppointmentCommand, RequestResponse>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public UpdateIdentityCardAppointmentCommandHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public async Task<RequestResponse> Handle(UpdateIdentityCardAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardAppointmentService.UpdateIdentityCardAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateIdentityCardAppointmentCommandValidator : AbstractValidator<UpdateIdentityCardAppointmentCommand>
    {
        public UpdateIdentityCardAppointmentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Reason).NotEmpty().NotNull();
            RuleFor(v => v.AppointmentDay).NotEmpty().NotNull();
            RuleFor(v => v.AdditionalInformation).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
        }
    }
}
