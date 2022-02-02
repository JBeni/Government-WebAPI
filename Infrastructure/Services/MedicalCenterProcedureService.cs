namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalCenterProcedureService : IMedicalCenterProcedureService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public MedicalCenterProcedureService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateMedicalCenterProcedure(CreateMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalCenterProcedure = _dbContext.MedicalCenterProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenterProcedure != null)
            {
                throw new Exception("The medical center procedure already exists");
            }
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);

            var entity = new MedicalCenterProcedure
            {
                MedicalCenter = medicalCenter.Item,
                MedicalProcedure = medicalProcedure.Item
            };

            _dbContext.MedicalCenterProcedures.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteMedicalCenterProcedure(DeleteMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalCenterProcedure = _dbContext.MedicalCenterProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenterProcedure != null)
            {
                throw new Exception("The medical center procedure already exists");
            }

            _dbContext.MedicalCenterProcedures.Remove(medicalCenterProcedure);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalCenterProcedure.Identifier);
        }

        public Result<MedicalCenterProcedureResponse> GetMedicalCenterProcedureById(GetMedicalCenterProcedureByIdQuery query)
        {
            var result = _dbContext.MedicalCenterProcedures
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalCenterProcedureResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<MedicalCenterProcedureResponse> { Successful = true, Item = result ?? new MedicalCenterProcedureResponse() };
        }

        public Result<MedicalCenterProcedureResponse> GetMedicalCenterProcedures(GetMedicalCenterProceduresQuery query)
        {
            var result = _dbContext.MedicalCenterProcedures
                .ProjectTo<MedicalCenterProcedureResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<MedicalCenterProcedureResponse> { Successful = true, Items = result ?? new List<MedicalCenterProcedureResponse>() };
        }

        public async Task<RequestResponse> UpdateMedicalCenterProcedure(UpdateMedicalCenterProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalCenterProcedure = _dbContext.MedicalCenterProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenterProcedure != null)
            {
                throw new Exception("The medical center procedure already exists");
            }
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var medicalProcedure = _insideEntityService.GetMedicalProcedureById(command.MedicalProcedureId);

            medicalCenterProcedure.MedicalCenter = medicalCenter.Item;
            medicalCenterProcedure.MedicalProcedure = medicalProcedure.Item;

            _dbContext.MedicalCenterProcedures.Update(medicalCenterProcedure);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalCenterProcedure.Identifier);

        }
    }
}
