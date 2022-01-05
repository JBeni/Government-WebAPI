namespace GovernmentSystem.Application.Handlers.Companies.Queries
{
    public class GetCompanyByIdQuery : IRequest<CompanyResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, CompanyResponse>
    {
        private readonly ICompanyService _companyService;

        public GetCompanyByIdQueryHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Task<CompanyResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _companyService.GetCompanyById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the company by Id", ex);
            }
        }
    }
}
