namespace GovernmentSystem.Infrastructure.Services
{
    public class MedicalCenterService : IMedicalCenterService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public MedicalCenterService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateMedicalCenter(CreateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter != null)
            {
                throw new Exception("The medical center already exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);
            var entity = new MedicalCenter
            {
                Address = address.Item,
                CenterName = command.CenterName,
                ConstructionDate = command.ConstructionDate,
            };

            _dbContext.MedicalCenters.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteMedicalCenter(DeleteMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter == null)
            {
                throw new Exception("The medical center does not exists");
            }

            _dbContext.MedicalCenters.Remove(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalCenter.Identifier);
        }

        public Result<MedicalCenterResponse> GetMedicalCenterById(GetMedicalCenterByIdQuery query)
        {
            var result = _dbContext.MedicalCenters
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<MedicalCenterResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<MedicalCenterResponse> { Successful = true, Item = result ?? new MedicalCenterResponse() };
        }

        public Result<MedicalCenterResponse> GetMedicalCenters(GetMedicalCentersQuery query)
        {
            var result = _dbContext.MedicalCenters
                .ProjectTo<MedicalCenterResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<MedicalCenterResponse> { Successful = true, Items = result ?? new List<MedicalCenterResponse>() };
        }

        public async Task<RequestResponse> UpdateMedicalCenter(UpdateMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var medicalCenter = _dbContext.MedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (medicalCenter == null)
            {
                throw new Exception("The medical center does not exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);

            medicalCenter.Address = address.Item;
            medicalCenter.CenterName = command.CenterName;
            medicalCenter.ConstructionDate = command.ConstructionDate;

            _dbContext.MedicalCenters.Update(medicalCenter);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(medicalCenter.Identifier);
        }
    }
}
