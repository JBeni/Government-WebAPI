using GovernmentSystem.Application.Handlers.Companies.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GovernmentSystem.Application.Handlers.Companies.Queries;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<RequestResponse> CreateCompany(CreateCompanyCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCompany(DeleteCompanyCommand command, CancellationToken cancellationToken);
        CompanyResponse GetCompanyById(GetCompanyByIdQuery query);
        List<CompanyResponse> GetCompanies(GetCompaniesQuery query);
        Task<RequestResponse> UpdateCompany(UpdateCompanyCommand command, CancellationToken cancellationToken);
    }
}
