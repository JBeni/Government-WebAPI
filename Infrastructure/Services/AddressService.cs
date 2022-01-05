namespace GovernmentSystem.Infrastructure.Services
{
    public class AddressService : IAddressService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public AddressService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateAddress(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (address != null)
            {
                throw new Exception("The address already exists");
            }
            var addressType = _insideEntityService.GetAddressTypeById(command.AddressTypeId);
            var entity = new Address
            {
                Country = command.Country,
                County = command.County,
                Street = command.Street,
                Type = addressType,
                ZipCode = command.ZipCode
            };

            _dbContext.Addresses.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteAddress(DeleteAddressCommand command, CancellationToken cancellationToken)
        {
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (address == null)
            {
                throw new Exception("The address does not exists");
            }

            _dbContext.Addresses.Remove(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public List<AddressResponse> GetAddressByCounty(GetAddressByCountyQuery query)
        {
            var result = _dbContext.Addresses
                .Where(v => v.County == query.County)
                .ProjectTo<AddressResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public AddressResponse GetAddressById(GetAddressByIdQuery query)
        {
            var result = _dbContext.Addresses
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<AddressResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<AddressResponse> GetAddressByType(GetAddressByTypeQuery query)
        {
            var result = _dbContext.Addresses
                .Where(v => v.Type.Type == query.Type)
                .ProjectTo<AddressResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public List<AddressResponse> GetAddresses(GetAddressesQuery query)
        {
            var result = _dbContext.Addresses
                .ProjectTo<AddressResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateAddress(UpdateAddressCommand command, CancellationToken cancellationToken)
        {
            var address = _dbContext.Addresses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (address == null)
            {
                throw new Exception("The address does not exists");
            }
            var addressType = _insideEntityService.GetAddressTypeById(command.AddressTypeId);
            address.Country = command.Country;
            address.County = command.County;
            address.Street = command.Street;
            address.ZipCode = command.ZipCode;
            address.Type = addressType;

            _dbContext.Addresses.Update(address);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
