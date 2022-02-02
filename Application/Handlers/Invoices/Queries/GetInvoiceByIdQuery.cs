namespace GovernmentSystem.Application.Handlers.Invoices.Queries
{
    public class GetInvoiceByIdQuery : IRequest<Result<InvoiceResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Result<InvoiceResponse>>
    {
        private readonly IInvoiceService _invoiceService;

        public GetInvoiceByIdQueryHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public Task<Result<InvoiceResponse>> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _invoiceService.GetInvoiceById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<InvoiceResponse>
                {
                    Error = $"There was an error retrieving the invoice by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
