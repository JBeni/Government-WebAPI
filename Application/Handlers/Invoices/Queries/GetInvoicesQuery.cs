namespace GovernmentSystem.Application.Handlers.Invoices.Queries
{
    public class GetInvoicesQuery : IRequest<Result<InvoiceResponse>>
    {
    }

    public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, Result<InvoiceResponse>>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoicesQueryHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task<Result<InvoiceResponse>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _invoiceService.GetInvoices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<InvoiceResponse>
                {
                    Error = $"There was an error retrieving the invoices. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
