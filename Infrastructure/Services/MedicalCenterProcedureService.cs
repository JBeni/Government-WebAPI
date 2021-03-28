﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Commands;
using GovernmentSystem.Application.Handlers.MedicalCenterProcedures.Queries;
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
    public class MedicalCenterProcedureService : IMedicalCenterProcedureService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedicalCenterProcedureService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateMedicalCenterProcedure(CreateMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalCenterProcedure = _dbContext.MedicalCenterProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenterProcedure != null)
            {
                throw new Exception("The medical center procedure already exists");
            }
            var entity = new MedicalCenterProcedure
            {
                MedicalCenter = command.MedicalCenter,
                MedicalProcedure = command.MedicalProcedure
            };

            _dbContext.MedicalCenterProcedures.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteMedicalCenterProcedure(DeleteMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalCenterProcedure = _dbContext.MedicalCenterProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenterProcedure != null)
            {
                throw new Exception("The medical center procedure already exists");
            }

            _dbContext.MedicalCenterProcedures.Remove(medicalCenterProcedure);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public MedicalCenterProcedureResponse GetMedicalCenterProcedureById(GetMedicalCenterProcedureByIdQuery query)
        {
            var result = _dbContext.MedicalCenterProcedures
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalCenterProcedureResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<MedicalCenterProcedureResponse> GetMedicalCenterProcedures(GetMedicalCenterProceduresQuery query)
        {
            var result = _dbContext.MedicalCenterProcedures
                .ProjectTo<MedicalCenterProcedureResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateMedicalCenterProcedure(UpdateMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalCenterProcedure = _dbContext.MedicalCenterProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenterProcedure != null)
            {
                throw new Exception("The medical center procedure already exists");
            }
            medicalCenterProcedure.MedicalCenter = command.MedicalCenter;
            medicalCenterProcedure.MedicalProcedure = command.MedicalProcedure;

            _dbContext.MedicalCenterProcedures.Update(medicalCenterProcedure);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();

        }
    }
}
