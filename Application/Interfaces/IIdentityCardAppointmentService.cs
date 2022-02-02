namespace GovernmentSystem.Application.Interfaces
{
    public interface IIdentityCardAppointmentService
    {
        Task<RequestResponse> CreateIdentityCardAppointment(CreateIdentityCardAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteIdentityCardAppointment(DeleteIdentityCardAppointmentCommand command, CancellationToken cancellationToken);
        Result<IdentityCardAppointmentResponse> GetIdentityCardAppointmentById(GetIdentityCardAppointmentByIdQuery query);
        Result<IdentityCardAppointmentResponse> GetIdentityCardAppointments(GetIdentityCardAppointmentsQuery query);
        Task<RequestResponse> UpdateIdentityCardAppointment(UpdateIdentityCardAppointmentCommand command, CancellationToken cancellationToken);
    }
}
