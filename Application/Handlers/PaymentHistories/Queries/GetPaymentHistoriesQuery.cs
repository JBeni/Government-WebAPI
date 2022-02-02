namespace GovernmentSystem.Application.Handlers.PaymentHistories.Queries
{
    public class GetPaymentHistoriesQuery : IRequest<Result<PaymentHistoryResponse>>
    {
    }

    public class GetPaymentHistoriesQueryHandler : IRequestHandler<GetPaymentHistoriesQuery, Result<PaymentHistoryResponse>>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public GetPaymentHistoriesQueryHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public Task<Result<PaymentHistoryResponse>> Handle(GetPaymentHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _paymentHistoryService.GetPaymentHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PaymentHistoryResponse>
                {
                    Error = $"There was an error retrieving the payment histories. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
