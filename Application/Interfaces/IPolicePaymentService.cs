namespace GovernmentSystem.Application.Interfaces
{
    public interface IPolicePaymentService
    {
        Task<RequestResponse> CreatePolicePayment(CreatePolicePaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePolicePayment(DeletePolicePaymentCommand command, CancellationToken cancellationToken);
        PolicePaymentResponse GetPolicePaymentById(GetPolicePaymentByIdQuery query);
        List<PolicePaymentResponse> GetPolicePayments(GetPolicePaymentsQuery query);
        Task<RequestResponse> UpdatePolicePayment(UpdatePolicePaymentCommand command, CancellationToken cancellationToken);
    }
}
