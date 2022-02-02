namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Commands
{
    public class DeleteSeriousFraudOfficeCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteSeriousFraudOfficeCommandHandler : IRequestHandler<DeleteSeriousFraudOfficeCommand, RequestResponse>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public DeleteSeriousFraudOfficeCommandHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public async Task<RequestResponse> Handle(DeleteSeriousFraudOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _seriousFraudOfficeService.DeleteSeriousFraudOffice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteSeriousFraudOfficeCommandValidator : AbstractValidator<DeleteSeriousFraudOfficeCommand>
    {
        public DeleteSeriousFraudOfficeCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
