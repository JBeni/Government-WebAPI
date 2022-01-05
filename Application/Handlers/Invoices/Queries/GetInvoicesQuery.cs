namespace GovernmentSystem.Application.Handlers.Invoices.Queries
{
    public class GetInvoicesQuery : IRequest<List<InvoiceResponse>>
    {
    }

    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, List<InvoiceResponse>>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoicesQueryHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task<List<InvoiceResponse>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _invoiceService.GetInvoices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the invoices", ex);
            }
        }
    }
}
