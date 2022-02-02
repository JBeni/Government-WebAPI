namespace GovernmentSystem.Application.Handlers.Companies.Queries
{
    public class GetCompaniesQuery : IRequest<Result<CompanyResponse>>
    {
    }

    public class GetCompanysQueryHandler : IRequestHandler<GetCompaniesQuery, Result<CompanyResponse>>
    {
        private readonly ICompanyService _companyService;

        public GetCompanysQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Task<Result<CompanyResponse>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _companyService.GetCompanies(request);
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
