namespace GovernmentSystem.Infrastructure.Services
{
    public class FraudOfficeReportProblemService : IFraudOfficeReportProblemService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public FraudOfficeReportProblemService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateFraudOfficeReportProblem(CreateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken)
        {
            var fraudOfficeReportProblem = _dbContext.FraudOfficeReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (fraudOfficeReportProblem != null)
            {
                throw new Exception("The fraud office report problem already exists");
            }
            var seriousFraudOffice = _insideEntityService.GetSeriousFraudOfficeById(command.SeriousFraudOfficeId);
            var entity = new FraudOfficeReportProblem
            {
                Title = command.Title,
                Description = command.Description,
                IsProcessed = false,
                SeriousFraudOffice = seriousFraudOffice.Item
            };

            _dbContext.FraudOfficeReportProblems.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteFraudOfficeReportProblem(DeleteFraudOfficeReportProblemCommand command, CancellationToken cancellationToken)
        {
            var fraudOfficeReportProblem = _dbContext.FraudOfficeReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (fraudOfficeReportProblem != null)
            {
                throw new Exception("The fraud office report problem does not exists");
            }

            _dbContext.FraudOfficeReportProblems.Remove(fraudOfficeReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(fraudOfficeReportProblem.Identifier);
        }

        public Result<FraudOfficeReportProblemResponse> GetFraudOfficeReportProblemById(GetFraudOfficeReportProblemByIdQuery query)
        {
            var result = _dbContext.FraudOfficeReportProblems
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<FraudOfficeReportProblemResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<FraudOfficeReportProblemResponse> { Successful = true, Item = result ?? new FraudOfficeReportProblemResponse() };
        }

        public Result<FraudOfficeReportProblemResponse> GetFraudOfficeReportProblems(GetFraudOfficeReportProblemsQuery query)
        {
            var result = _dbContext.FraudOfficeReportProblems
                .ProjectTo<FraudOfficeReportProblemResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<FraudOfficeReportProblemResponse> { Successful = true, Items = result ?? new List<FraudOfficeReportProblemResponse>() };
        }

        public async Task<RequestResponse> UpdateFraudOfficeReportProblem(UpdateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken)
        {
            var fraudOfficeReportProblem = _dbContext.FraudOfficeReportProblems.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (fraudOfficeReportProblem != null)
            {
                throw new Exception("The fraud office report problem does not exists");
            }
            var seriousFraudOffice = _insideEntityService.GetSeriousFraudOfficeById(command.SeriousFraudOfficeId);

            fraudOfficeReportProblem.Title = command.Title;
            fraudOfficeReportProblem.Description = command.Description;
            fraudOfficeReportProblem.IsProcessed = command.IsProcessed;
            fraudOfficeReportProblem.SeriousFraudOffice = seriousFraudOffice.Item;

            _dbContext.FraudOfficeReportProblems.Update(fraudOfficeReportProblem);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(fraudOfficeReportProblem.Identifier);
        }
    }
}
