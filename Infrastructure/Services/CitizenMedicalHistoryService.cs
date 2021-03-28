using AutoMapper;
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

            var entity = new CitizenMedicalHistory
            {
                AdditionalInformation = command.AdditionalInformation,
                MedicalAppointment = command.MedicalAppointment,
                Citizen = command.Citizen,
                DateOfDiagnostic = command.DateOfDiagnostic,
                HealthProblem = command.HealthProblem,
                MedicalCenter = command.MedicalCenter,
                PublicServantGP = command.PublicServantGP,
                Symptoms = command.Symptoms,
                Treatment = command.Treatment,
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
            citizenMedicalHistory.AdditionalInformation = command.AdditionalInformation;
            citizenMedicalHistory.MedicalAppointment = command.MedicalAppointment;
            citizenMedicalHistory.Citizen = command.Citizen;
            citizenMedicalHistory.DateOfDiagnostic = command.DateOfDiagnostic;
            citizenMedicalHistory.HealthProblem = command.HealthProblem;
            citizenMedicalHistory.MedicalCenter = command.MedicalCenter;
            citizenMedicalHistory.PublicServantGP = command.PublicServantGP;
            citizenMedicalHistory.Symptoms = command.Symptoms;
            citizenMedicalHistory.Treatment = command.Treatment;

            _dbContext.CitizenMedicalHistories.Update(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
