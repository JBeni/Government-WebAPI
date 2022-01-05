namespace GovernmentSystem.Application.Handlers.PaymentHistories.Queries
{
    public class GetPaymentHistoriesQuery : IRequest<List<PaymentHistoryResponse>>
    {
    }

    public class GetPaymentHistoriesQueryHandler : IRequestHandler<GetPaymentHistoriesQuery, List<PaymentHistoryResponse>>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public GetPaymentHistoriesQueryHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public Task<List<PaymentHistoryResponse>> Handle(GetPaymentHistoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _paymentHistoryService.GetPaymentHistories(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the payment histories", ex);
            }
        }
    }
}
