using GovernmentSystem.Application.Handlers.Taxes.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.Taxes.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ITaxService
    {
        Task<RequestResponse> CreateTax(CreateTaxCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteTax(DeleteTaxCommand command, CancellationToken cancellationToken);
        TaxResponse GetTaxById(GetTaxByIdQuery query);
        List<TaxResponse> GetTaxes(GetTaxesQuery query);
        Task<RequestResponse> UpdateTax(UpdateTaxCommand command, CancellationToken cancellationToken);
    }
}
