namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Commands
{
    public class UpdateSeriousFraudOfficeCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string OfficeName { get; set; }
        public DateTime ConstructionDate { get; set; }
        public Guid AddressId { get; set; }
    }

    public class UpdateSeriousFraudOfficeCommandHandler : IRequestHandler<UpdateSeriousFraudOfficeCommand, RequestResponse>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public UpdateSeriousFraudOfficeCommandHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public async Task<RequestResponse> Handle(UpdateSeriousFraudOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _seriousFraudOfficeService.UpdateSeriousFraudOffice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateSeriousFraudOfficeCommandValidator : AbstractValidator<UpdateSeriousFraudOfficeCommand>
    {
        public UpdateSeriousFraudOfficeCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.OfficeName).NotEmpty().NotNull();
            RuleFor(v => v.ConstructionDate).NotEmpty().NotNull();
            RuleFor(v => v.AddressId).NotEmpty().NotNull();
        }
    }
}
