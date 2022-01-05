namespace GovernmentSystem.Infrastructure.Services
{
    public class SeriousFraudOfficeService : ISeriousFraudOfficeService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IInsideEntityService _insideEntityService;

        public SeriousFraudOfficeService(IApplicationDbContext dbContext, IMapper mapper, IInsideEntityService insideEntityService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _insideEntityService = insideEntityService;
        }

        public async Task<RequestResponse> CreateSeriousFraudOffice(CreateSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            var seriousFraudOffice = _dbContext.SeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (seriousFraudOffice != null)
            {
                throw new Exception("The serious fraud office already exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);
            var entity = new SeriousFraudOffice
            {
                Address = address,
                ConstructionDate = command.ConstructionDate,
                OfficeName = command.OfficeName
            };

            _dbContext.SeriousFraudOffices.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public async Task<RequestResponse> DeleteSeriousFraudOffice(DeleteSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            var seriousFraudOffice = _dbContext.SeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (seriousFraudOffice != null)
            {
                throw new Exception("The serious fraud office does not exists");
            }

            _dbContext.SeriousFraudOffices.Remove(seriousFraudOffice);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }

        public SeriousFraudOfficeResponse GetSeriousFraudOfficeById(GetSeriousFraudOfficeByIdQuery query)
        {
            var result = _dbContext.SeriousFraudOffices
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<SeriousFraudOfficeResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return result;
        }

        public List<SeriousFraudOfficeResponse> GetSeriousFraudOffices(GetSeriousFraudOfficesQuery query)
        {
            var result = _dbContext.SeriousFraudOffices
                .ProjectTo<SeriousFraudOfficeResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        public async Task<RequestResponse> UpdateSeriousFraudOffice(UpdateSeriousFraudOfficeCommand command, CancellationToken cancellationToken)
        {
            var seriousFraudOffice = _dbContext.SeriousFraudOffices.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (seriousFraudOffice != null)
            {
                throw new Exception("The serious fraud office does not exists");
            }
            var address = _insideEntityService.GetAddressById(command.AddressId);

            seriousFraudOffice.Address = address;
            seriousFraudOffice.ConstructionDate = command.ConstructionDate;
            seriousFraudOffice.OfficeName = command.OfficeName;

            _dbContext.SeriousFraudOffices.Update(seriousFraudOffice);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success();
        }
    }
}
