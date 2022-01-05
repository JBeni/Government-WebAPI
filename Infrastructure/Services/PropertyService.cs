namespace GovernmentSystem.Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PropertyService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateProperty(CreatePropertyCommand command, CancellationToken cancellationToken)
        {
            var property = _dbContext.Properties.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (property != null)
            {
                throw new Exception("The property already exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var address = _insideEntityService.GetAddressById(command.AddressId);
            var propertyType = _insideEntityService.GetPropertyTypeById(command.TypeId);

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
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var address = _insideEntityService.GetAddressById(command.AddressId);
            var propertyType = _insideEntityService.GetPropertyTypeById(command.TypeId);

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
