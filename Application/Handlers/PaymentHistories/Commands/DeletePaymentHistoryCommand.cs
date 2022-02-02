namespace GovernmentSystem.Application.Handlers.PaymentHistories.Commands
{
    public class DeletePaymentHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePaymentHistoryCommandHandler : IRequestHandler<DeletePaymentHistoryCommand, RequestResponse>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public DeletePaymentHistoryCommandHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public async Task<RequestResponse> Handle(DeletePaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentHistoryService.DeletePaymentHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeletePaymentHistoryCommandValidator : AbstractValidator<DeletePaymentHistoryCommand>
    {
        public DeletePaymentHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
