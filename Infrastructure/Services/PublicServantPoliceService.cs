using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Commands;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.PublicServantEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantPoliceService : IPublicServantPoliceService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PublicServantPoliceService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreatePublicServantPolice(CreatePublicServantPoliceCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantPolices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of police station already exists");
            }
            var policeStation = _dbContext.PoliceStations.SingleOrDefault(x => x.Identifier == command.PoliceStationId);
            var entity = new PublicServantPolice
            {
                PoliceStation = policeStation,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantPolices.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeletePublicServantPolice(DeletePublicServantPoliceCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantPolices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of police station does not exists");
            }

            _dbContext.PublicServantPolices.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public PublicServantPoliceResponse GetPublicServantPoliceById(GetPublicServantPoliceByIdQuery query)
        {
            var result = _dbContext.PublicServantPolices
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantPoliceResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<PublicServantPoliceResponse> GetPublicServantPolices(GetPublicServantPolicesQuery query)
        {
            var result = _dbContext.PublicServantPolices
                .ProjectTo<PublicServantPoliceResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdatePublicServantPolice(UpdatePublicServantPoliceCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantPolices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of police station does not exists");
            }
            var policeStation = _dbContext.PoliceStations.SingleOrDefault(x => x.Identifier == command.PoliceStationId);

            _dbContext.PublicServantPolices.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
