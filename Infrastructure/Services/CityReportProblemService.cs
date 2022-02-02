namespace GovernmentSystem.Infrastructure.Services
{
    public class CityReportProblemService : ICityReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public CityReportProblemService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateCityReportProblem(CreateCityReportProblemCommand command, CancellationToken cancellationToken)
        {
            var CityReportProblem = _dbContext.CityReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (CityReportProblem != null)
            {
                throw new Exception("The city hall reported problem already exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);
            var entity = new CityReportProblem
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Description = command.Description,
                IsProcessed = false,
                Title = command.Title,
                CityHall = cityHall.Item
            };

            _dbContext.CityReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteCityReportProblem(DeleteCityReportProblemCommand command, CancellationToken cancellationToken)
        {
            var CityReportProblem = _dbContext.CityReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (CityReportProblem == null)
            {
                throw new Exception("The city hall reported problem does not exists");
            }

            _dbContext.CityReportProblems.Remove(CityReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(CityReportProblem.Identifier);
        }

        public Result<CityReportProblemResponse> GetCityReportProblemById(GetCityReportProblemByIdQuery query)
        {
            var result = _dbContext.CityReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<CityReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<CityReportProblemResponse> { Successful = true, Item = result ?? new CityReportProblemResponse() };
        }

        public Result<CityReportProblemResponse> GetCityReportProblems(GetCityReportProblemsQuery query)
        {
            var result = _dbContext.CityReportProblems
                .ProjectTo<CityReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<CityReportProblemResponse> { Successful = true, Items = result ?? new List<CityReportProblemResponse>() };
        }

        public async Task<RequestResponse> UpdateCityReportProblem(UpdateCityReportProblemCommand command, CancellationToken cancellationToken)
        {
            var CityReportProblem = _dbContext.CityReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (CityReportProblem == null)
            {
                throw new Exception("The city hall reported problem does not exists");
            }
            var cityHall = _insideEntityService.GetCityHallById(command.CityHallId);

            CityReportProblem.DateOfExpiry = command.DateOfExpiry;
            CityReportProblem.DateOfIssue = command.DateOfIssue;
            CityReportProblem.Description = command.Description;
            CityReportProblem.Title = command.Title;
            CityReportProblem.IsProcessed = command.IsProcessed;
            CityReportProblem.CityHall = cityHall.Item;

            _dbContext.CityReportProblems.Update(CityReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(CityReportProblem.Identifier);
        }
    }
}
