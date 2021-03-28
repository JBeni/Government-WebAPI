﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantGPs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantGPs.Queries;
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
    public class PublicServantGPService : IPublicServantGPService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PublicServantGPService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreatePublicServantGP(CreatePublicServantGPCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantGPs.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of GP already exists");
            }
            var entity = new PublicServantGP
            {
                MedicalCenter = command.MedicalCenter,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantGPs.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeletePublicServantGP(DeletePublicServantGPCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantGPs.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of GP does not exists");
            }

            _dbContext.PublicServantGPs.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public PublicServantGPResponse GetPublicServantGPById(GetPublicServantGPByIdQuery query)
        {
            var result = _dbContext.PublicServantGPs
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantGPResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<PublicServantGPResponse> GetPublicServantGPs(GetPublicServantGPsQuery query)
        {
            var result = _dbContext.PublicServantGPs
                .ProjectTo<PublicServantGPResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdatePublicServantGP(UpdatePublicServantGPCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantGPs.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of GP does not exists");
            }

            _dbContext.PublicServantGPs.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
