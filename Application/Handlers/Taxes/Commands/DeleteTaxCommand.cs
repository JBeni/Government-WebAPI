namespace GovernmentSystem.Application.Handlers.Taxes.Commands
{
    public class DeleteTaxCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteTaxCommandHandler : IRequestHandler<DeleteTaxCommand, RequestResponse>
    {
        private readonly ITaxService _taxService;

        public DeleteTaxCommandHandler(ITaxService taxService)
        {
            _taxService = taxService;
        }

        public async Task<RequestResponse> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _taxService.DeleteTax(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteTaxCommandValidator : AbstractValidator<DeleteTaxCommand>
    {
        public DeleteTaxCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
