namespace GovernmentSystem.Application.Handlers.Companies.Queries
{
    public class GetCompanyByIdQuery : IRequest<Result<CompanyResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Result<CompanyResponse>>
    {
        private readonly ICompanyService _companyService;

        public GetCompanyByIdQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Task<Result<CompanyResponse>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _companyService.GetCompanyById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CompanyResponse>
                {
                    Error = $"There was an error retrieving the company by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
