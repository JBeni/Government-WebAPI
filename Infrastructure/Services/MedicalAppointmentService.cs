using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Appointments.Commands;
using GovernmentSystem.Application.Handlers.MedicalAppointments.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.MedicalEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IApplicationDbContext _dbContext;

        public MedicalAppointmentService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> CreateMedicalAppointment(CreateMedicalAppointmentCommand command, CancellationToken cancellationToken)
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

        public async Task<RequestResponse> DeleteMedicalAppointment(DeleteMedicalAppointmentCommand command, CancellationToken cancellationToken)
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

        public MedicalAppointmentResponse GetMedicalAppointmentById(GetMedicalAppointmentByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<MedicalAppointmentsResponse> GetMedicalAppointments(GetMedicalAppointmentsQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResponse> UpdateMedicalAppointment(UpdateMedicalAppointmentCommand command, CancellationToken cancellationToken)
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
