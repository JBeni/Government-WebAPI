namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalProcedureService : IMedicalProcedureService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedicalProcedureService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateMedicalProcedure(CreateMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalProcedure = _dbContext.MedicalProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalProcedure != null)
            {
                throw new Exception("The medical procedure already exists");
            }
            var entity = new MedicalProcedure
            {
                AdditionalInformation = command.AdditionalInformation,
                Price = command.Price,
                ProcedureDuration = command.ProcedureDuration,
                ProcedureName = command.ProcedureName
            };

            _dbContext.MedicalProcedures.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteMedicalProcedure(DeleteMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalProcedure = _dbContext.MedicalProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalProcedure != null)
            {
                throw new Exception("The medical procedure does not exists");
            }

            _dbContext.MedicalProcedures.Remove(medicalProcedure);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalProcedure.Identifier);
        }

        public Result<MedicalProcedureResponse> GetMedicalProcedureById(GetMedicalProcedureByIdQuery query)
        {
            var result = _dbContext.MedicalProcedures
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalProcedureResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<MedicalProcedureResponse> { Successful = true, Item = result ?? new MedicalProcedureResponse() };
        }

        public Result<MedicalProcedureResponse> GetMedicalProcedures(GetMedicalProceduresQuery query)
        {
            var result = _dbContext.MedicalProcedures
                .ProjectTo<MedicalProcedureResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<MedicalProcedureResponse> { Successful = true, Items = result ?? new List<MedicalProcedureResponse>() };
        }

        public async Task<RequestResponse> UpdateMedicalProcedure(UpdateMedicalProcedureCommand command, CancellationToken cancellationToken)
        {
            var medicalProcedure = _dbContext.MedicalProcedures.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalProcedure != null)
            {
                throw new Exception("The medical procedure does not exists");
            }
            medicalProcedure.AdditionalInformation = command.AdditionalInformation;
            medicalProcedure.Price = command.Price;
            medicalProcedure.ProcedureDuration = command.ProcedureDuration;
            medicalProcedure.ProcedureName = command.ProcedureName;

            _dbContext.MedicalProcedures.Update(medicalProcedure);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalProcedure.Identifier);
        }
    }
}
