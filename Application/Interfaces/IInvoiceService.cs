using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Invoices.Commands;
using GovernmentSystem.Application.Handlers.Invoices.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<RequestResponse> CreateInvoice(CreateInvoiceCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteInvoice(DeleteInvoiceCommand command, CancellationToken cancellationToken);
        InvoiceResponse GetInvoiceById(GetInvoiceByIdQuery query);
        List<InvoiceResponse> GetInvoices(GetInvoicesQuery query);
        Task<RequestResponse> UpdateInvoice(UpdateInvoiceCommand command, CancellationToken cancellationToken);
    }
}
