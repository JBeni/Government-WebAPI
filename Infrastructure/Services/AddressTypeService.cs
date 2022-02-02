namespace GovernmentSystem.Infrastructure.Services
{
    public class AddressTypeService : IAddressTypeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddressTypeService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Result<AddressTypeResponse> GetAddressTypeById(GetAddressTypeByIdQuery query)
        {
            var result = _dbContext.AddressTypes
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<AddressTypeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<AddressTypeResponse> { Successful = true, Item = result ?? new AddressTypeResponse() };
        }

        public Result<AddressTypeResponse> GetAddressTypes(GetAddressTypesQuery query)
        {
            var result = _dbContext.AddressTypes
                .ProjectTo<AddressTypeResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<AddressTypeResponse> { Successful = true, Items = result ?? new List<AddressTypeResponse>() };
        }
    }
}
