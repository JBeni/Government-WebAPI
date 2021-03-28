using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Commands;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantCityHallService : IPublicServantCityHallService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PublicServantCityHallService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreatePublicServantCityHall(CreatePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantCityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of city hall already exists");
            }
            var entity = new PublicServantCityHall
            {
                CityHall = command.CityHall,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantCityHalls.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeletePublicServantCityHall(DeletePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantCityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of city hall does not exists");
            }

            _dbContext.PublicServantCityHalls.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public PublicServantCityHallResponse GetPublicServantCityHallById(GetPublicServantCityHallByIdQuery query)
        {
            var result = _dbContext.PublicServantCityHalls
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantCityHallResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<PublicServantCityHallResponse> GetPublicServantCityHalls(GetPublicServantCityHallsQuery query)
        {
            var result = _dbContext.PublicServantCityHalls
                .ProjectTo<PublicServantCityHallResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdatePublicServantCityHall(UpdatePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantCityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of city hall does not exists");
            }

            _dbContext.PublicServantCityHalls.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
