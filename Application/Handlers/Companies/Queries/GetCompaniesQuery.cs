namespace GovernmentSystem.Application.Handlers.Companies.Queries
{
    public class GetCompaniesQuery : IRequest<List<CompanyResponse>>
    {
    }

    public class GetCompanysQueryHandler : IRequestHandler<GetCompaniesQuery, List<CompanyResponse>>
    {
        private readonly ICompanyService _companyService;

        public GetCompanysQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Task<List<CompanyResponse>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _companyService.GetCompanies(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the company by Id", ex);
            }
        }
    }
}
