namespace GovernmentSystem.Application.Handlers.PaymentHistories.Queries
{
    public class GetPaymentHistoryByIdQuery : IRequest<PaymentHistoryResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPaymentHistoryByIdQueryHandler : IRequestHandler<GetPaymentHistoryByIdQuery, PaymentHistoryResponse>
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public GetPaymentHistoryByIdQueryHandler(IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        public Task<PaymentHistoryResponse> Handle(GetPaymentHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _paymentHistoryService.GetPaymentHistoryById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the payment history by Id", ex);
            }
        }
    }
}
