using GovernmentSystem.Application.Handlers.Properties.Commands;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GovernmentSystem.Application.Handlers.Properties.Queries;
using GovernmentSystem.Application.Responses;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateProperty(CreatePropertyCommand command, CancellationToken cancellationToken)
        {
            var property = _dbContext.Properties.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (property != null)
            {
                throw new Exception("The property already exists");
            }
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.CityHallId);
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.AddressId);
            var propertyType = _dbContext.PropertyTypes.SingleOrDefault(x => x.Identifier == command.TypeId);

            var entity = new Property
            {
                Address = address,
                ValueAtBuying = command.ValueAtBuying,
                CityHall = cityHall,
                CurrentValue = command.CurrentValue,
                Size = command.Size,
                Type = propertyType,
                UnitOfMeasure = command.UnitOfMeasure
            };

            _dbContext.Properties.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteProperty(DeletePropertyCommand command, CancellationToken cancellationToken)
        {
            var property = _dbContext.Properties.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (property == null)
            {
                throw new Exception("The property does not exists");
            }

            _dbContext.Properties.Remove(property);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public List<PropertyResponse> GetProperties(GetPropertiesQuery query)
        {
            var result = _dbContext.Properties
                .ProjectTo<PropertyResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public PropertyResponse GetPropertyById(GetPropertyByIdQuery query)
        {
            var result = _dbContext.Properties
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PropertyResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public async Task<RequestResponse> UpdateProperty(UpdatePropertyCommand command, CancellationToken cancellationToken)
        {
            var property = _dbContext.Properties.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (property == null)
            {
                throw new Exception("The property does not exists");
            }
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.CityHallId);
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.AddressId);
            var propertyType = _dbContext.PropertyTypes.SingleOrDefault(x => x.Identifier == command.TypeId);

            property.Address = address;
            property.ValueAtBuying = command.ValueAtBuying;
            property.CityHall = cityHall;
            property.CurrentValue = command.CurrentValue;
            property.Size = command.Size;
            property.Type = propertyType;
            property.UnitOfMeasure = command.UnitOfMeasure;

            _dbContext.Properties.Update(property);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
