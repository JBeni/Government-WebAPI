using GovernmentSystem.Application.Handlers.Appointments.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.MedicalAppointments.Queries;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalAppointmentService
    {
        Task<RequestResponse> CreateMedicalAppointment(CreateMedicalAppointmentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalAppointment(DeleteMedicalAppointmentCommand command, CancellationToken cancellationToken);
        MedicalAppointmentResponse GetMedicalAppointmentById(GetMedicalAppointmentByIdQuery query);
        List<MedicalAppointmentsResponse> GetMedicalAppointments(GetMedicalAppointmentsQuery query);
        Task<RequestResponse> UpdateMedicalAppointment(UpdateMedicalAppointmentCommand command, CancellationToken cancellationToken);
    }
}
