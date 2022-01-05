namespace GovernmentSystem.Application.Handlers.PaymentHistories.Commands
{
    public class UpdatePaymentHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InstitutionType { get; set; }
        public long AmountToPay { get; set; }
        public long AmountPaid { get; set; }
        public DateTime DateOfPayment { get; set; }
        public Guid CitizenWhoPaidId { get; set; }
    }

    public class UpdatePaymentHistoryCommandHandler : IRequestHandler<UpdatePaymentHistoryCommand, RequestResponse>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public UpdatePaymentHistoryCommandHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public async Task<RequestResponse> Handle(UpdatePaymentHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _paymentHistoryService.UpdatePaymentHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdatePaymentHistoryCommandValidator : AbstractValidator<UpdatePaymentHistoryCommand>
    {
        public UpdatePaymentHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.InstitutionType).NotEmpty().NotNull();
            RuleFor(v => v.AmountToPay).NotEmpty().NotNull();
            RuleFor(v => v.AmountPaid).NotEmpty().NotNull();
            RuleFor(v => v.DateOfPayment).NotEmpty().NotNull();
            RuleFor(v => v.CitizenWhoPaidId).NotEmpty().NotNull();
        }
    }
}
