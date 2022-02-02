namespace GovernmentSystem.Application.Interfaces
{
    public interface IPolicePaymentService
    {
        Task<RequestResponse> CreatePolicePayment(CreatePolicePaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePolicePayment(DeletePolicePaymentCommand command, CancellationToken cancellationToken);
        Result<PolicePaymentResponse> GetPolicePaymentById(GetPolicePaymentByIdQuery query);
        Result<PolicePaymentResponse> GetPolicePayments(GetPolicePaymentsQuery query);
        Task<RequestResponse> UpdatePolicePayment(UpdatePolicePaymentCommand command, CancellationToken cancellationToken);
    }
}
