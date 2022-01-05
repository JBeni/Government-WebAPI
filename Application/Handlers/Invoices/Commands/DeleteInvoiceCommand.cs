namespace GovernmentSystem.Application.Handlers.Invoices.Commands
{
    public class DeleteInvoiceCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, RequestResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public DeleteInvoiceCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<RequestResponse> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _invoiceService.DeleteInvoice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        public DeleteInvoiceCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
