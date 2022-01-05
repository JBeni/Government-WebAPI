namespace GovernmentSystem.Application.Handlers.IdentityCardAppointments.Commands
{
    public class DeleteIdentityCardAppointmentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteIdentityCardAppointmentCommandHandler : IRequestHandler<DeleteIdentityCardAppointmentCommand, RequestResponse>
    {
        private readonly IIdentityCardAppointmentService _identityCardAppointmentService;

        public DeleteIdentityCardAppointmentCommandHandler(IIdentityCardAppointmentService identityCardAppointmentService)
        {
            _identityCardAppointmentService = identityCardAppointmentService;
        }

        public async Task<RequestResponse> Handle(DeleteIdentityCardAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardAppointmentService.DeleteIdentityCardAppointment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteIdentityCardAppointmentCommandValidator : AbstractValidator<DeleteIdentityCardAppointmentCommand>
    {
        public DeleteIdentityCardAppointmentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
