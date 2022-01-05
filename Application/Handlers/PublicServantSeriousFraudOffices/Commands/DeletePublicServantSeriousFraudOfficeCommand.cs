namespace GovernmentSystem.Application.Handlers.PublicServantSeriousFraudOffices.Commands
{
    public class DeletePublicServantSeriousFraudOfficeCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePublicServantSeriousFraudOfficeHandler : IRequestHandler<DeletePublicServantSeriousFraudOfficeCommand, RequestResponse>
    {
        private readonly IPublicServantSeriousFraudOfficeservice _publicServantSeriousFraudOfficesService;

        public DeletePublicServantSeriousFraudOfficeHandler(IPublicServantSeriousFraudOfficeservice publicServantSeriousFraudOfficeService)
        {
            _publicServantSeriousFraudOfficesService = publicServantSeriousFraudOfficeService;
        }

        public async Task<RequestResponse> Handle(DeletePublicServantSeriousFraudOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSeriousFraudOfficesService.DeletePublicServantSeriousFraudOffice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePublicServantSeriousFraudOfficeHandlerValidator : AbstractValidator<DeletePublicServantSeriousFraudOfficeCommand>
    {
        public DeletePublicServantSeriousFraudOfficeHandlerValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
