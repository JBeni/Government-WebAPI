namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantCityHallService : IPublicServantCityHallService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PublicServantCityHallService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePublicServantCityHall(CreatePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantCityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of city hall already exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var entity = new PublicServantCityHall
            {
                CityHall = cityHall.Item,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantCityHalls.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePublicServantCityHall(DeletePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantCityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of city hall does not exists");
            }

            _dbContext.PublicServantCityHalls.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }

        public Result<PublicServantCityHallResponse> GetPublicServantCityHallById(GetPublicServantCityHallByIdQuery query)
        {
            var result = _dbContext.PublicServantCityHalls
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantCityHallResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PublicServantCityHallResponse> { Successful = true, Item = result ?? new PublicServantCityHallResponse() };
        }

        public Result<PublicServantCityHallResponse> GetPublicServantCityHalls(GetPublicServantCityHallsQuery query)
        {
            var result = _dbContext.PublicServantCityHalls
                .ProjectTo<PublicServantCityHallResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PublicServantCityHallResponse> { Successful = true, Items = result ?? new List<PublicServantCityHallResponse>() };
        }

        public async Task<RequestResponse> UpdatePublicServantCityHall(UpdatePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantCityHalls.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of city hall does not exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);

            publicServant.CityHall = cityHall.Item;
            publicServant.CNP = command.CNP;
            publicServant.ContractYears = command.ContractYears;
            publicServant.DutyRole = command.DutyRole;
            publicServant.FirstName = command.FirstName;
            publicServant.HireEndDate = command.HireEndDate;
            publicServant.HireStartDate = command.HireStartDate;
            publicServant.LastName = command.LastName;

            _dbContext.PublicServantCityHalls.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }
    }
}
