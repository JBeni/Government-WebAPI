namespace GovernmentSystem.Application.Handlers.Regularizations.Commands
{
    public class UpdateRegularizationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Informations { get; set; }
        public string LawName { get; set; }
        public string ModificationRequired { get; set; }
        public string CompanyImpact { get; set; }
    }

    public class UpdateRegularizationCommandHandler : IRequestHandler<UpdateRegularizationCommand, RequestResponse>
    {
        private readonly IRegularizationService _regularizationService;

        public UpdateRegularizationCommandHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public async Task<RequestResponse> Handle(UpdateRegularizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _regularizationService.UpdateRegularization(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateRegularizationCommandValidator : AbstractValidator<UpdateRegularizationCommand>
    {
        public UpdateRegularizationCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Informations).NotEmpty().NotNull();
            RuleFor(v => v.LawName).NotEmpty().NotNull();
            RuleFor(v => v.ModificationRequired).NotEmpty().NotNull();
            RuleFor(v => v.CompanyImpact).NotEmpty().NotNull();
        }
    }
}
