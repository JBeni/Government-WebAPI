namespace GovernmentSystem.Application.Interfaces
{
    public interface IPaymentHistoryService
    {
        Task<RequestResponse> CreatePaymentHistory(CreatePaymentHistoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePaymentHistory(DeletePaymentHistoryCommand command, CancellationToken cancellationToken);
        PaymentHistoryResponse GetPaymentHistoryById(GetPaymentHistoryByIdQuery query);
        List<PaymentHistoryResponse> GetPaymentHistories(GetPaymentHistoriesQuery query);
        Task<RequestResponse> UpdatePaymentHistory(UpdatePaymentHistoryCommand command, CancellationToken cancellationToken);
    }
}
