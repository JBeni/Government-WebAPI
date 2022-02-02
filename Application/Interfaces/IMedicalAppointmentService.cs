namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalAppointmentService
    {
        Task<RequestResponse> CreateMedicalAppointment(CreateMedicalAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalAppointment(DeleteMedicalAppointmentCommand command, CancellationToken cancellationToken);
        Result<MedicalAppointmentResponse> GetMedicalAppointmentById(GetMedicalAppointmentByIdQuery query);
        Result<MedicalAppointmentResponse> GetMedicalAppointments(GetMedicalAppointmentsQuery query);
        Task<RequestResponse> UpdateMedicalAppointment(UpdateMedicalAppointmentCommand command, CancellationToken cancellationToken);
    }
}
