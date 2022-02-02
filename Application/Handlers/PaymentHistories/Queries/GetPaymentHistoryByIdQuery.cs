namespace GovernmentSystem.Application.Handlers.PaymentHistories.Queries
{
    public class GetPaymentHistoryByIdQuery : IRequest<Result<PaymentHistoryResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPaymentHistoryByIdQueryHandler : IRequestHandler<GetPaymentHistoryByIdQuery, Result<PaymentHistoryResponse>>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public GetPaymentHistoryByIdQueryHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public Task<Result<PaymentHistoryResponse>> Handle(GetPaymentHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _paymentHistoryService.GetPaymentHistoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PaymentHistoryResponse>
                {
                    Error = $"There was an error retrieving the payment history by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
