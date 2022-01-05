namespace GovernmentSystem.Application.Handlers.PublicServantSeriousFraudOffices.Commands
{
    public class UpdatePublicServantSeriousFraudOfficeCommand : IRequest<RequestResponse>
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

    public class UpdatePublicServantSeriousFraudOfficeCommandHandler : IRequestHandler<UpdatePublicServantSeriousFraudOfficeCommand, RequestResponse>
    {
        private readonly IPublicServantSeriousFraudOfficeservice _publicServantSeriousFraudOfficesService;

        public UpdatePublicServantSeriousFraudOfficeCommandHandler(IPublicServantSeriousFraudOfficeservice publicServantSeriousFraudOfficeService)
        {
            _publicServantSeriousFraudOfficesService = publicServantSeriousFraudOfficeService;
        }

        public async Task<RequestResponse> Handle(UpdatePublicServantSeriousFraudOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _publicServantSeriousFraudOfficesService.UpdatePublicServantSeriousFraudOffice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePublicServantSeriousFraudOfficeCommandValidator : AbstractValidator<UpdatePublicServantSeriousFraudOfficeCommand>
    {
        public UpdatePublicServantSeriousFraudOfficeCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
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
