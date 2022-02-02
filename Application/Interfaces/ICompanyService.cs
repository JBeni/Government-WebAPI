namespace GovernmentSystem.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<RequestResponse> CreateCompany(CreateCompanyCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCompany(DeleteCompanyCommand command, CancellationToken cancellationToken);
        Result<CompanyResponse> GetCompanyById(GetCompanyByIdQuery query);
        Result<CompanyResponse> GetCompanies(GetCompaniesQuery query);
        Task<RequestResponse> UpdateCompany(UpdateCompanyCommand command, CancellationToken cancellationToken);
    }
}
