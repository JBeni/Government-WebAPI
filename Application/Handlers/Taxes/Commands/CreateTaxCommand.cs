namespace GovernmentSystem.Application.Handlers.Taxes.Commands
{
    public class CreateTaxCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public Guid CitizenId { get; set; }
        public Guid CompanyId { get; set; }
    }

    public class CreateTaxCommandHandler : IRequestHandler<CreateTaxCommand, RequestResponse>
    {
        private readonly ITaxService _taxService;

        public CreateTaxCommandHandler(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public async Task<RequestResponse> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _taxService.CreateTax(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateTaxCommandValidator : AbstractValidator<CreateTaxCommand>
    {
        public CreateTaxCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
            RuleFor(v => v.CompanyId).NotEmpty().NotNull();
        }
    }
}
