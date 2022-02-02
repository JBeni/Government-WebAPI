namespace GovernmentSystem.Infrastructure.Services
{
    public class DriverLicenseService : IDriverLicenseService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DriverLicenseService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateDriverLicense(CreateDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            var driverLicense = _dbContext.DriverLicenses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (driverLicense != null)
            {
                throw new Exception("The driver license already exists");
            }
            var entity = new DriverLicense
            {
                LicenseNumber = command.LicenseNumber
            };

            _dbContext.DriverLicenses.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteDriverLicense(DeleteDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            var driverLicense = _dbContext.DriverLicenses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (driverLicense != null)
            {
                throw new Exception("The driver license does not exists");
            }

            _dbContext.DriverLicenses.Remove(driverLicense);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(driverLicense.Identifier);
        }

        public Result<DriverLicenseResponse> GetDriverLicenseById(GetDriverLicenseByIdQuery query)
        {
            var result = _dbContext.DriverLicenses
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<DriverLicenseResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<DriverLicenseResponse> { Successful = true, Item = result ?? new DriverLicenseResponse() };
        }

        public Result<DriverLicenseResponse> GetDriverLicenses(GetDriverLicensesQuery query)
        {
            var result = _dbContext.DriverLicenses
                .ProjectTo<DriverLicenseResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<DriverLicenseResponse> { Successful = true, Items = result ?? new List<DriverLicenseResponse>() };
        }

        public async Task<RequestResponse> UpdateDriverLicense(UpdateDriverLicenseCommand command, CancellationToken cancellationToken)
        {
            var driverLicense = _dbContext.DriverLicenses.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (driverLicense != null)
            {
                throw new Exception("The driver license does not exists");
            }
            driverLicense.LicenseNumber = command.LicenseNumber;

            _dbContext.DriverLicenses.Update(driverLicense);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(driverLicense.Identifier);
        }
    }
}
