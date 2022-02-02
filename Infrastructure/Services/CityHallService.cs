namespace GovernmentSystem.Infrastructure.Services
{
    public class CityHallService : ICityHallService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CityHallService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCityHall(CreateCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall != null)
            {
                throw new Exception("The city hall already exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);
            var entity = new CityHall
            {
                Identifier = command.Identifier,
                CityHallName = command.CityHallName,
                Address = address.Item,
                ConstructionDate = command.ConstructionDate
            };

            _dbContext.CityHalls.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCityHall(DeleteCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall == null)
            {
                throw new Exception("The city hall does not exists");
            }

            _dbContext.CityHalls.Remove(cityHall);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(cityHall.Identifier);
        }

        public Result<CityHallResponse> GetCityHallById(GetCityHallByIdQuery query)
        {
            var result = _dbContext.CityHalls
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<CityHallResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CityHallResponse> { Successful = true, Item = result ?? new CityHallResponse() };
        }

        public Result<CityHallResponse> GetCityHalls(GetCityHallsQuery query)
        {
            var result = _dbContext.CityHalls
                .ProjectTo<CityHallResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CityHallResponse> { Successful = true, Items = result ?? new List<CityHallResponse>() };
        }

        public async Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken)
        {
            var cityHall = _dbContext.CityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (cityHall == null)
            {
                throw new Exception("The city hall does not exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);
            cityHall.CityHallName = command.CityHallName;
            cityHall.Address = address.Item;
            cityHall.ConstructionDate = command.ConstructionDate;

            _dbContext.CityHalls.Update(cityHall);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(cityHall.Identifier);
        }
    }
}
