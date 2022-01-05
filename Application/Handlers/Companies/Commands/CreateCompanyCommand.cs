namespace GovernmentSystem.Application.Handlers.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string CIF { get; set; }
        public string Name { get; set; }
        public DateTime FoundationYear { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DeletionDate { get; set; }
        public Guid FounderId { get; set; }
        public Guid OfficeAddressId { get; set; }
    }

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, RequestResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<RequestResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _companyService.CreateCompany(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.CIF).NotEmpty().NotNull();
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.FoundationYear).NotEmpty().NotNull();
            RuleFor(v => v.Domain).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Status).NotEmpty().NotNull();
            RuleFor(v => v.DeletionDate).NotEmpty().NotNull();
            RuleFor(v => v.FounderId).NotEmpty().NotNull();
            RuleFor(v => v.OfficeAddressId).NotEmpty().NotNull();
        }
    }
}
