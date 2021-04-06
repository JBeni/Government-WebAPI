using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.IdentityCardAppointments.Commands;
using GovernmentSystem.Application.Handlers.IdentityCardAppointments.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
