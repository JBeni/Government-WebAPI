using GovernmentSystem.Application.Handlers.Appointments.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<RequestResponse> AddMedicalAppointment(CreateAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalAppointment(DeleteAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateMedicalAppointment(UpdateAppointmentCommand command, CancellationToken cancellationToken);
    }
}
