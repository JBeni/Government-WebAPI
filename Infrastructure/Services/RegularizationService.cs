namespace GovernmentSystem.Infrastructure.Services
{
    public class RegularizationService : IRegularizationService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public RegularizationService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateRegularization(CreateRegularizationCommand command, CancellationToken cancellationToken)
        {
            var regularization = _dbContext.Regularizations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (regularization != null)
            {
                throw new Exception("The regularization already exists");
            }
            var entity = new Regularization
            {
                CompanyImpact = command.CompanyImpact,
                Informations = command.Informations,
                LawName = command.LawName,
                ModificationRequired = command.ModificationRequired
            };

            _dbContext.Regularizations.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteRegularization(DeleteRegularizationCommand command, CancellationToken cancellationToken)
        {
            var regularization = _dbContext.Regularizations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (regularization == null)
            {
                throw new Exception("The regularization does not exists");
            }

            _dbContext.Regularizations.Remove(regularization);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(regularization.Identifier);
        }

        public Result<RegularizationResponse> GetRegularizations(GetRegularizationsQuery query)
        {
            var result = _dbContext.Regularizations
                .ProjectTo<RegularizationResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<RegularizationResponse> { Successful = true, Items = result ?? new List<RegularizationResponse>() };
        }

        public Result<RegularizationResponse> GetRegularizationById(GetRegularizationByIdQuery query)
        {
            var result = _dbContext.Regularizations
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<RegularizationResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<RegularizationResponse> { Successful = true, Item = result ?? new RegularizationResponse() };
        }

        public async Task<RequestResponse> UpdateRegularization(UpdateRegularizationCommand command, CancellationToken cancellationToken)
        {
            var regularization = _dbContext.Regularizations.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (regularization == null)
            {
                throw new Exception("The regularization does not exists");
            }
            regularization.CompanyImpact = command.CompanyImpact;
            regularization.Informations = command.Informations;
            regularization.LawName = command.LawName;
            regularization.ModificationRequired = command.ModificationRequired;


            _dbContext.Regularizations.Update(regularization);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(regularization.Identifier);
        }
    }
}
