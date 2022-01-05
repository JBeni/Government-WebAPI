namespace GovernmentSystem.Application.Interfaces
{
    public interface IIdentityCardAppointmentService
    {
        Task<RequestResponse> CreateIdentityCardAppointment(CreateIdentityCardAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteIdentityCardAppointment(DeleteIdentityCardAppointmentCommand command, CancellationToken cancellationToken);
        IdentityCardAppointmentResponse GetIdentityCardAppointmentById(GetIdentityCardAppointmentByIdQuery query);
        List<IdentityCardAppointmentResponse> GetIdentityCardAppointments(GetIdentityCardAppointmentsQuery query);
        Task<RequestResponse> UpdateIdentityCardAppointment(UpdateIdentityCardAppointmentCommand command, CancellationToken cancellationToken);
    }
}
