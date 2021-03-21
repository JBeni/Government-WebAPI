﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands;
using GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities;
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

        public async Task<RequestResponse> AddCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistory.SingleOrDefault(x => x.Id == command.Id);
            if (citizenMedicalHistory != null)
            {
                throw new Exception("The citizen medical history request already exists");
            }

            var entity = new CitizenMedicalHistory
            {
            };

            _dbContext.CitizenMedicalHistory.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistory.SingleOrDefault(x => x.Id == command.Id);
            if (citizenMedicalHistory == null)
            {
                throw new Exception("The citizen medical history request does not exists");
            }

            _dbContext.CitizenMedicalHistory.Remove(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public List<MedicalHistoryResponse> GetCitizenMedicalHistory(GetCitizenMedicalHistoryQuery query)
        {
            var result = _dbContext.CitizenMedicalHistory
                    .OrderBy(x => x.Id)
                    .ProjectTo<MedicalHistoryResponse>(_mapper.ConfigurationProvider)
                    .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken)
        {
            var citizenMedicalHistory = _dbContext.CitizenMedicalHistory.SingleOrDefault(x => x.Id == command.Id);
            if (citizenMedicalHistory == null)
            {
                throw new Exception("The citizen medical history request does not exists");
            }
            //citizenMedicalHistory.Some = "";

            _dbContext.CitizenMedicalHistory.Update(citizenMedicalHistory);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
