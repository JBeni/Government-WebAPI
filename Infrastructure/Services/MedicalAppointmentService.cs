using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.Appointments.Commands;
using GovernmentSystem.Application.Handlers.MedicalAppointments.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
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
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public MedicalAppointmentService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateMedicalAppointment(CreateMedicalAppointmentCommand command, CancellationToken cancellationToken)
        {
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalAppointment != null)
            {
                throw new Exception("The medical appointment already exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            var entity = new MedicalAppointment
            {
                AppointmentDay = command.AppointmentDay,
                Symptoms = command.Symptoms,
                Citizen = citizen,
                MedicalCenter = medicalCenter,
                MedicalProcedure = medicalProcedure,
                PublicServantMedicalCenter = publicServantMedicalCenter,
            };

            _dbContext.MedicalAppointments.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalAppointment(DeleteMedicalAppointmentCommand command, CancellationToken cancellationToken)
        {
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalAppointment == null)
            {
                throw new Exception("The medical appointment does not exists");
            }

            _dbContext.MedicalAppointments.Remove(medicalAppointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public MedicalAppointmentResponse GetMedicalAppointmentById(GetMedicalAppointmentByIdQuery query)
        {
            var result = _dbContext.MedicalAppointments
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalAppointmentResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<MedicalAppointmentResponse> GetMedicalAppointments(GetMedicalAppointmentsQuery query)
        {
            var result = _dbContext.MedicalAppointments
                .ProjectTo<MedicalAppointmentResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateMedicalAppointment(UpdateMedicalAppointmentCommand command, CancellationToken cancellationToken)
        {
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalAppointment == null)
            {
                throw new Exception("The medical appointment does not exists");
            }
            var citizen = _insideEntityService.GetCitizenById(command.CitizenId);
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);
            var publicServantMedicalCenter = _insideEntityService.GetPublicServantMedicalCenterById(command.PublicServantMedicalCenterId);

            medicalAppointment.AppointmentDay = command.AppointmentDay;
            medicalAppointment.Symptoms = command.Symptoms;
            medicalAppointment.MedicalCenter = medicalCenter;
            medicalAppointment.MedicalProcedure = medicalProcedure;
            medicalAppointment.PublicServantMedicalCenter = publicServantMedicalCenter;

            _dbContext.MedicalAppointments.Update(medicalAppointment);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
