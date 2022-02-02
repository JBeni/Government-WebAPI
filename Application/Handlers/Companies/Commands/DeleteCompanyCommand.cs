namespace GovernmentSystem.Application.Handlers.Companies.Commands
{
    public class DeleteCompanyCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, RequestResponse>
    {
        private readonly ICompanyService _companyService;

        public DeleteCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<RequestResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _companyService.DeleteCompany(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
