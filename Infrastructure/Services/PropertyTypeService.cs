using AutoMapper;
using AutoMapper.QueryableExtensions;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Application.Handlers.PropertyTypes.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Linq;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PropertyTypeService : IPropertyTypeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyTypeService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PropertyTypeResponse GetPropertyTypeById(GetPropertyTypeByIdQuery query)
        {
            var result = _dbContext.PropertyTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PropertyTypeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<PropertyTypeResponse> GetPropertyTypes(GetPropertyTypesQuery query)
        {
            var result = _dbContext.PropertyTypes
                .ProjectTo<PropertyTypeResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }
    }
}
