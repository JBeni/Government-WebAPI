namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantPoliceStationService : IPublicServantPoliceStationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PublicServantPoliceStationService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePublicServantPoliceStation(CreatePublicServantPoliceStationCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantPoliceStations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of police station already exists");
            }
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);
            var entity = new PublicServantPoliceStation
            {
                PoliceStation = policeStation.Item,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantPoliceStations.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePublicServantPoliceStation(DeletePublicServantPoliceStationCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantPoliceStations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of police station does not exists");
            }

            _dbContext.PublicServantPoliceStations.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }

        public Result<PublicServantPoliceStationResponse> GetPublicServantPoliceStationById(GetPublicServantPoliceStationByIdQuery query)
        {
            var result = _dbContext.PublicServantPoliceStations
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantPoliceStationResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PublicServantPoliceStationResponse> { Successful = true, Item = result ?? new PublicServantPoliceStationResponse() };
        }

        public Result<PublicServantPoliceStationResponse> GetPublicServantPoliceStations(GetPublicServantPoliceStationsQuery query)
        {
            var result = _dbContext.PublicServantPoliceStations
                .ProjectTo<PublicServantPoliceStationResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PublicServantPoliceStationResponse> { Successful = true, Items = result ?? new List<PublicServantPoliceStationResponse>() };
        }

        public async Task<RequestResponse> UpdatePublicServantPoliceStation(UpdatePublicServantPoliceStationCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantPoliceStations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of police station does not exists");
            }
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);

            publicServant.PoliceStation = policeStation.Item;
            publicServant.CNP = command.CNP;
            publicServant.ContractYears = command.ContractYears;
            publicServant.DutyRole = command.DutyRole;
            publicServant.FirstName = command.FirstName;
            publicServant.HireEndDate = command.HireEndDate;
            publicServant.HireStartDate = command.HireStartDate;
            publicServant.LastName = command.LastName;

            _dbContext.PublicServantPoliceStations.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }
    }
}
