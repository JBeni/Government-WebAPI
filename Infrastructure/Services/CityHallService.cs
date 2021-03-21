using GovernmentSystem.Application.Handlers.CityHalls.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class CityHallService : ICityHallService
    {
        private readonly IApplicationDbContext _dbContext;

        public CityHallService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> AddCityHall(CreateCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall != null)
            {
                throw new Exception("The city hall already exists");
            }

            var entity = new CityHall
            {
                Identifier = command.Identifier,
                Name = command.Name,
                Address = command.Address,
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

            //cityHall.IsErased = command.IsErased;

            _dbContext.CityHalls.Update(cityHall);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }

        public async Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall == null)
            {
                throw new Exception("The city hall does not exists");
            }

            cityHall.Name = command.Name;
            cityHall.Address = command.Address;

            _dbContext.CityHalls.Update(cityHall);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return RequestResponse.Success();
        }
    }
}
