﻿namespace GovernmentSystem.Infrastructure.Services
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

        public Result<PropertyTypeResponse> GetPropertyTypeById(GetPropertyTypeByIdQuery query)
        {
            var result = _dbContext.PropertyTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PropertyTypeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PropertyTypeResponse> { Successful = true, Item = result ?? new PropertyTypeResponse() };
        }

        public Result<PropertyTypeResponse> GetPropertyTypes(GetPropertyTypesQuery query)
        {
            var result = _dbContext.PropertyTypes
                .ProjectTo<PropertyTypeResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PropertyTypeResponse> { Successful = true, Items = result ?? new List<PropertyTypeResponse>() };
        }
    }
}
