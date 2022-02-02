namespace GovernmentSystem.Application.Handlers.PublicServantSeriousFraudOffices.Commands
{
    public class CreatePublicServantSeriousFraudOfficeCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DutyRole { get; set; }
        public int ContractYears { get; set; }
        public DateTime HireStartDate { get; set; }
        public DateTime HireEndDate { get; set; }
        public Guid SeriousFraudOfficeId { get; set; }
    }

    public class CreatePublicServantSeriousFraudOfficeCommandHandler : IRequestHandler<CreatePublicServantSeriousFraudOfficeCommand, RequestResponse>
    {
        private readonly IPublicServantSeriousFraudOfficeservice _publicServantSeriousFraudOfficesService;

        public CreatePublicServantSeriousFraudOfficeCommandHandler(IPublicServantSeriousFraudOfficeservice publicServantSeriousFraudOfficeService)
        {
            _publicServantSeriousFraudOfficesService = publicServantSeriousFraudOfficeService;
        }

        public async Task<RequestResponse> Handle(CreatePublicServantSeriousFraudOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSeriousFraudOfficesService.CreatePublicServantSeriousFraudOffice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreatePublicServantSeriousFraudOfficeCommandValidator : AbstractValidator<CreatePublicServantSeriousFraudOfficeCommand>
    {
        public CreatePublicServantSeriousFraudOfficeCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CNP).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.DutyRole).NotEmpty().NotNull();
            RuleFor(v => v.ContractYears).NotEmpty().NotNull();
            RuleFor(v => v.HireStartDate).NotEmpty().NotNull();
            RuleFor(v => v.HireEndDate).NotEmpty().NotNull();
            RuleFor(v => v.SeriousFraudOfficeId).NotEmpty().NotNull();
        }
    }
}
