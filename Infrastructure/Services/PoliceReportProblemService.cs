namespace GovernmentSystem.Infrastructure.Services
{
    public class PoliceReportProblemService : IPoliceReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PoliceReportProblemService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePoliceReportProblem(CreatePoliceReportProblemCommand command, CancellationToken cancellationToken)
        {
            var policeReportProblem = _dbContext.PoliceReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policeReportProblem != null)
            {
                throw new Exception("The police report problem already exists");
            }
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);
            var entity = new PoliceReportProblem
            {
                Title = command.Title,
                Description = command.Description,
                IsProcessed = false,
                PoliceStation = policeStation.Item
            };

            _dbContext.PoliceReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePoliceReportProblem(DeletePoliceReportProblemCommand command, CancellationToken cancellationToken)
        {
            var policeReportProblem = _dbContext.PoliceReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policeReportProblem != null)
            {
                throw new Exception("The police report problem does not exists");
            }

            _dbContext.PoliceReportProblems.Remove(policeReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(policeReportProblem.Identifier);
        }

        public Result<PoliceReportProblemResponse> GetPoliceReportProblemById(GetPoliceReportProblemByIdQuery query)
        {
            var result = _dbContext.PoliceReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PoliceReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PoliceReportProblemResponse> { Successful = true, Item = result ?? new PoliceReportProblemResponse() };
        }

        public Result<PoliceReportProblemResponse> GetPoliceReportProblems(GetPoliceReportProblemsQuery query)
        {
            var result = _dbContext.PoliceReportProblems
                .ProjectTo<PoliceReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PoliceReportProblemResponse> { Successful = true, Items = result ?? new List<PoliceReportProblemResponse>() };
        }

        public async Task<RequestResponse> UpdatePoliceReportProblem(UpdatePoliceReportProblemCommand command, CancellationToken cancellationToken)
        {
            var policeReportProblem = _dbContext.PoliceReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (policeReportProblem != null)
            {
                throw new Exception("The police report problem does not exists");
            }
            var policeStation = _insideEntityService.GetPoliceStationById(command.PoliceStationId);

            policeReportProblem.Title = command.Title;
            policeReportProblem.Description = command.Description;
            policeReportProblem.IsProcessed = command.IsProcessed;
            policeReportProblem.PoliceStation = policeStation.Item;

            _dbContext.PoliceReportProblems.Update(policeReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(policeReportProblem.Identifier);
        }
    }
}
