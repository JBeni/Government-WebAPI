namespace GovernmentSystem.Application.Handlers.Invoices.Commands
{
    public class UpdateInvoiceCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, RequestResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public UpdateInvoiceCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<RequestResponse> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _invoiceService.UpdateInvoice(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.InstitutionType).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.IssuedDate).NotEmpty().NotNull();
            RuleFor(v => v.DueDate).NotEmpty().NotNull();
        }
    }
}
