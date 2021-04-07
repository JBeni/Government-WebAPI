using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Invoices.Queries
{
    public class GetInvoiceByIdQuery : IRequest<InvoiceResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, InvoiceResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoiceByIdQueryHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task<InvoiceResponse> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _invoiceService.GetInvoiceById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the invoice by Id", ex);
            }
        }
    }
}
