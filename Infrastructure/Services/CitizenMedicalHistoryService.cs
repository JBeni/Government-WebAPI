﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries;
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
    public class CitizenMedicalHistoryService : ICitizenMedicalHistoryService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CitizenMedicalHistoryService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenMedicalHistory != null)
            {
                throw new Exception("The citizen medical history request already exists");
            }
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.MedicalCenterId);
            var publicServantGP = _dbContext.PublicServantGPs.SingleOrDefault(x => x.Identifier == command.PublicServantGPId);
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.MedicalAppointmentId);
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.CitizenId);

            var entity = new CitizenMedicalHistory
            {
                AdditionalInformation = command.AdditionalInformation,
                DateOfDiagnostic = command.DateOfDiagnostic,
                HealthProblem = command.HealthProblem,
                Symptoms = command.Symptoms,
                Treatment = command.Treatment,
                MedicalCenter = medicalCenter,
                PublicServantGP = publicServantGP,
                MedicalAppointment = medicalAppointment,
                Citizen = citizen,
            };

            _dbContext.CitizenMedicalHistories.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenMedicalHistory == null)
            {
                throw new Exception("The citizen medical history request does not exists");
            }

            _dbContext.CitizenMedicalHistories.Remove(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public List<CitizenMedicalHistoryResponse> GetCitizenMedicalHistories(GetCitizenMedicalHistoriesQuery query)
        {
            var result = _dbContext.CitizenMedicalHistories
                .ProjectTo<CitizenMedicalHistoryResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public CitizenMedicalHistoryResponse GetCitizenMedicalHistoryById(GetCitizenMedicalHistoryByIdQuery query)
        {
            var result = _dbContext.CitizenMedicalHistories
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CitizenMedicalHistoryResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public async Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistories.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (citizenMedicalHistory == null)
            {
                throw new Exception("The citizen medical history request does not exists");
            }
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.MedicalCenterId);
            var publicServantGP = _dbContext.PublicServantGPs.SingleOrDefault(x => x.Identifier == command.PublicServantGPId);
            var medicalAppointment = _dbContext.MedicalAppointments.SingleOrDefault(x => x.Identifier == command.MedicalAppointmentId);
            var citizen = _dbContext.Citizens.SingleOrDefault(x => x.Identifier == command.CitizenId);

            citizenMedicalHistory.AdditionalInformation = command.AdditionalInformation;
            citizenMedicalHistory.Treatment = command.Treatment;
            citizenMedicalHistory.Citizen = citizen;
            citizenMedicalHistory.MedicalAppointment = medicalAppointment;
            citizenMedicalHistory.MedicalCenter = medicalCenter;
            citizenMedicalHistory.PublicServantGP = publicServantGP;

            _dbContext.CitizenMedicalHistories.Update(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
