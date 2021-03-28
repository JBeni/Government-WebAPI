using GovernmentSystem.Application.Handlers.CityHalls.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CityHalls.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CityHallService : ICityHallService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CityHallService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateCityHall(CreateCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall != null)
            {
                throw new Exception("The city hall already exists");
            }
            var entity = new CityHall
            {
                Identifier = command.Identifier,
                CityHallName = command.CityHallName,
                Address = command.Address,
                ConstructionDate = command.ConstructionDate
            };

            _dbContext.CityHalls.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteCityHall(DeleteCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall == null)
            {
                throw new Exception("The city hall does not exists");
            }

            _dbContext.CityHalls.Update(cityHall);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public CityHallResponse GetCityHallById(GetCityHallByIdQuery query)
        {
            var result = _dbContext.CityHalls
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CityHallResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<CityHallResponse> GetCityHalls(GetCityHallsQuery query)
        {
            var result = _dbContext.CityHalls
                .ProjectTo<CityHallResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall == null)
            {
                throw new Exception("The city hall does not exists");
            }
            cityHall.CityHallName = command.CityHallName;
            cityHall.Address = command.Address;

            _dbContext.CityHalls.Update(cityHall);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
