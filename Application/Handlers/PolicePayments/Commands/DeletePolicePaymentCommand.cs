namespace GovernmentSystem.Application.Handlers.PolicePayments.Commands
{
    public class DeletePolicePaymentCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePolicePaymentCommandHandler : IRequestHandler<DeletePolicePaymentCommand, RequestResponse>
    {
        private readonly IPolicePaymentService _policePaymentService;

        public DeletePolicePaymentCommandHandler(IPolicePaymentService policePaymentService)
        {
            _policePaymentService = policePaymentService;
        }

        public async Task<RequestResponse> Handle(DeletePolicePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policePaymentService.DeletePolicePayment(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePolicePaymentCommandValidator : AbstractValidator<DeletePolicePaymentCommand>
    {
        public DeletePolicePaymentCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
