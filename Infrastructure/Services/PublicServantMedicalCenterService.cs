namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantMedicalCenterService : IPublicServantMedicalCenterService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public PublicServantMedicalCenterService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreatePublicServantMedicalCenter(CreatePublicServantMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantMedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of medical center already exists");
            }
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);
            var entity = new PublicServantMedicalCenter
            {
                MedicalCenter = medicalCenter.Item,
                CNP = command.CNP,
                ContractYears = command.ContractYears,
                DutyRole = command.DutyRole,
                FirstName = command.FirstName,
                HireEndDate = command.HireEndDate,
                HireStartDate = command.HireStartDate,
                LastName = command.LastName
            };

            _dbContext.PublicServantMedicalCenters.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePublicServantMedicalCenter(DeletePublicServantMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantMedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of medical center does not exists");
            }

            _dbContext.PublicServantMedicalCenters.Remove(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }

        public Result<PublicServantMedicalCenterResponse> GetPublicServantMedicalCenterById(GetPublicServantMedicalCenterByIdQuery query)
        {
            var result = _dbContext.PublicServantMedicalCenters
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PublicServantMedicalCenterResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PublicServantMedicalCenterResponse>
            {
                Successful = true,
                Item = result ?? new PublicServantMedicalCenterResponse()
            };
        }

        public Result<PublicServantMedicalCenterResponse> GetPublicServantMedicalCenters(GetPublicServantMedicalCentersQuery query)
        {
            var result = _dbContext.PublicServantMedicalCenters
                .ProjectTo<PublicServantMedicalCenterResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PublicServantMedicalCenterResponse>
            {
                Successful = true,
                Items = result ?? new List<PublicServantMedicalCenterResponse>()
            };
        }

        public async Task<RequestResponse> UpdatePublicServantMedicalCenter(UpdatePublicServantMedicalCenterCommand command, CancellationToken cancellationToken)
        {
            var publicServant = _dbContext.PublicServantMedicalCenters.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (publicServant != null)
            {
                throw new Exception("The public servant of medical center does not exists");
            }
            var medicalCenter = _insideEntityService.GetMedicalCenterById(command.MedicalCenterId);

            publicServant.MedicalCenter = medicalCenter.Item;
            publicServant.CNP = command.CNP;
            publicServant.ContractYears = command.ContractYears;
            publicServant.DutyRole = command.DutyRole;
            publicServant.FirstName = command.FirstName;
            publicServant.HireEndDate = command.HireEndDate;
            publicServant.HireStartDate = command.HireStartDate;
            publicServant.LastName = command.LastName;

            _dbContext.PublicServantMedicalCenters.Update(publicServant);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(publicServant.Identifier);
        }
    }
}
