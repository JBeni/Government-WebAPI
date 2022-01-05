namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalAppointmentService
    {
        Task<RequestResponse> CreateMedicalAppointment(CreateMedicalAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalAppointment(DeleteMedicalAppointmentCommand command, CancellationToken cancellationToken);
        MedicalAppointmentResponse GetMedicalAppointmentById(GetMedicalAppointmentByIdQuery query);
        List<MedicalAppointmentResponse> GetMedicalAppointments(GetMedicalAppointmentsQuery query);
        Task<RequestResponse> UpdateMedicalAppointment(UpdateMedicalAppointmentCommand command, CancellationToken cancellationToken);
    }
}
