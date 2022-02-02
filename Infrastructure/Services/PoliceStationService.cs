namespace GovernmentSystem.Infrastructure.Services
{
    public class PoliceStationService : IPoliceStationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PoliceStationService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePoliceStation(CreatePoliceStationCommand command, CancellationToken cancellationToken)
        {
            var policeStation = _dbContext.PoliceStations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policeStation != null)
            {
                throw new Exception("The police station already exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var address = _insideEntityService.GetAddressById(command.AddressId);

            var entity = new PoliceStation
            {
                Address = address.Item,
                CityHall = cityHall.Item,
                ConstructionDate = command.ConstructionDate,
                StationName = command.StationName
            };

            _dbContext.PoliceStations.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePoliceStation(DeletePoliceStationCommand command, CancellationToken cancellationToken)
        {
            var policeStation = _dbContext.PoliceStations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policeStation != null)
            {
                throw new Exception("The police station does not exists");
            }

            _dbContext.PoliceStations.Remove(policeStation);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(policeStation.Identifier);
        }

        public Result<PoliceStationResponse> GetPoliceStationById(GetPoliceStationByIdQuery query)
        {
            var result = _dbContext.PoliceStations
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PoliceStationResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PoliceStationResponse> { Successful = true, Item = result ?? new PoliceStationResponse() };
        }

        public Result<PoliceStationResponse> GetPoliceStations(GetPoliceStationsQuery query)
        {
            var result = _dbContext.PoliceStations
                .ProjectTo<PoliceStationResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PoliceStationResponse> { Successful = true, Items = result ?? new List<PoliceStationResponse>() };
        }

        public async Task<RequestResponse> UpdatePoliceStation(UpdatePoliceStationCommand command, CancellationToken cancellationToken)
        {
            var policeStation = _dbContext.PoliceStations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policeStation != null)
            {
                throw new Exception("The police station does not exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var address = _insideEntityService.GetAddressById(command.AddressId);

            policeStation.Address = address.Item;
            policeStation.CityHall = cityHall.Item;
            policeStation.ConstructionDate = command.ConstructionDate;
            policeStation.StationName = command.StationName;

            _dbContext.PoliceStations.Update(policeStation);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(policeStation.Identifier);
        }
    }
}
