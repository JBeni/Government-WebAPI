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

namespace GovernmentSystem.Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IApplicationDbContext _dbContext;

        public PropertyService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestResponse> CreateProperty(CreatePropertyCommand command, CancellationToken cancellationToken)
        {
            var property = _dbContext.Properties.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (property != null)
            {
                throw new Exception("The property already exists");
            }

            var entity = new Property
            {
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

            _dbContext.Properties.Add(property);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public List<PropertyResponse> GetProperties(GetPropertiesQuery query)
        {
            throw new NotImplementedException();
        }

        public PropertyResponse GetPropertyById(GetPropertyByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<RequestResponse> UpdateProperty(UpdatePropertyCommand command, CancellationToken cancellationToken)
        {
            var property = _dbContext.Properties.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (property == null)
            {
                throw new Exception("The property does not exists");
            }
            property.CurrentValue = "";

            _dbContext.Properties.Add(property);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
