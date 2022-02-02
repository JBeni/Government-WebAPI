namespace GovernmentSystem.Application.Handlers.Regularizations.Commands
{
    public class CreateRegularizationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Informations { get; set; }
        public string LawName { get; set; }
        public string ModificationRequired { get; set; }
        public string CompanyImpact { get; set; }
    }

    public class CreateRegularizationCommandHandler : IRequestHandler<CreateRegularizationCommand, RequestResponse>
    {
        private readonly IRegularizationService _regularizationService;

        public CreateRegularizationCommandHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public async Task<RequestResponse> Handle(CreateRegularizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _regularizationService.CreateRegularization(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateRegularizationCommandValidator : AbstractValidator<CreateRegularizationCommand>
    {
        public CreateRegularizationCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Informations).NotEmpty().NotNull();
            RuleFor(v => v.LawName).NotEmpty().NotNull();
            RuleFor(v => v.ModificationRequired).NotEmpty().NotNull();
            RuleFor(v => v.CompanyImpact).NotEmpty().NotNull();
        }
    }
}
