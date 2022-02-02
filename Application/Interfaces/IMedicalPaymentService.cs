namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalPaymentService
    {
        Task<RequestResponse> CreateMedicalPayment(CreateMedicalPaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalPayment(DeleteMedicalPaymentCommand command, CancellationToken cancellationToken);
        Result<MedicalPaymentResponse> GetMedicalPaymentById(GetMedicalPaymentByIdQuery query);
        Result<MedicalPaymentResponse> GetMedicalPayments(GetMedicalPaymentsQuery query);
        Task<RequestResponse> UpdateMedicalPayment(UpdateMedicalPaymentCommand command, CancellationToken cancellationToken);
    }
}
