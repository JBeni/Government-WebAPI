using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries;
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
    public class PublicServantSFOService : IPublicServantSFOService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PublicServantSFOService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreatePublicServantSFO(CreatePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantSFOs.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of serious fraud office already exists");
            }
            var sfo = _dbContext.SeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.SFOId);
            var entity = new PublicServantSFO
            {
                SFO = sfo,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantSFOs.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeletePublicServantSFO(DeletePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantSFOs.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of serious fraud office does not exists");
            }

            _dbContext.PublicServantSFOs.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public PublicServantSFOResponse GetPublicServantSFOById(GetPublicServantSFOByIdQuery query)
        {
            var result = _dbContext.PublicServantSFOs
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantSFOResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<PublicServantSFOResponse> GetPublicServantSFOs(GetPublicServantSFOsQuery query)
        {
            var result = _dbContext.PublicServantSFOs
                .ProjectTo<PublicServantSFOResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdatePublicServantSFO(UpdatePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantSFOs.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of serious fraud office does not exists");
            }
            var sfo = _dbContext.SeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.SFOId);

            _dbContext.PublicServantSFOs.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();

        }
    }
}
