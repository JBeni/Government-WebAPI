using GovernmentSystem.Application.Handlers.Appointments.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Domain.Entities.MedicalEntities;

namespace GovernmentSystem.Infrastructure.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IApplicationDbContext _dbContext;

        public AppointmentService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> AddMedicalAppointment(CreateAppointmentCommand command, CancellationToken cancellationToken)
        {
            var appointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Id == command.Id);
            if (appointment != null)
            {
                throw new Exception("The appointment already exists");
            }

            var entity = new MedicalAppointment
            {
            };

            _dbContext.MedicalAppointments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalAppointment(DeleteAppointmentCommand command, CancellationToken cancellationToken)
        {
            var appointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Id == command.Id);
            if (appointment == null)
            {
                throw new Exception("The appointment does not exists");
            }

            _dbContext.MedicalAppointments.Remove(appointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateMedicalAppointment(UpdateAppointmentCommand command, CancellationToken cancellationToken)
        {
            var appointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Id == command.Id);
            if (appointment == null)
            {
                throw new Exception("The appointment does not exists");
            }
            //appointment.Some = "";

            _dbContext.MedicalAppointments.Update(appointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
