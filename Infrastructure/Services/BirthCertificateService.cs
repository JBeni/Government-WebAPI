namespace GovernmentSystem.Infrastructure.Services
{
    public class BirthCertificateService : IBirthCertificateService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public BirthCertificateService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateBirthCertificate(CreateBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _dbContext.BirthCertificates.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (birthCertificate != null)
            {
                throw new Exception("The birth certificate already exists");
            }
            var entity = new BirthCertificate
            {
                BirthDate = command.BirthDate,
                BirthPlace = command.BirthPlace,
                Country = command.Country,
                Father = command.Father,
                FirstName = command.FirstName,
                RegistrationDate = command.RegistrationDate,
                LastName = command.LastName,
                Mother = command.Mother,
                PersonalIdentificationNumber = command.PersonalIdentificationNumber,
                RegistrationPlace = command.RegistrationPlace,
                Series = command.Series,
            };

            _dbContext.BirthCertificates.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteBirthCertificate(DeleteBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _dbContext.BirthCertificates.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (birthCertificate != null)
            {
                throw new Exception("The birth certificate does not exists");
            }

            _dbContext.BirthCertificates.Remove(birthCertificate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(birthCertificate.Identifier);
        }

        public Result<BirthCertificateResponse> GetBirthCertificateById(GetBirthCertificateByIdQuery query)
        {
            var result = _dbContext.BirthCertificates
                .Where(v => v.Identifier == query.Identifier)
                .ProjectTo<BirthCertificateResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<BirthCertificateResponse> { Successful = true, Item = result ?? new BirthCertificateResponse() };
        }

        public Result<BirthCertificateResponse> GetBirthCertificates(GetBirthCertificatesQuery query)
        {
            var result = _dbContext.BirthCertificates
                .ProjectTo<BirthCertificateResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<BirthCertificateResponse> { Successful = true, Items = result ?? new List<BirthCertificateResponse>() };
        }

        public async Task<RequestResponse> UpdateBirthCertificate(UpdateBirthCertificateCommand command, CancellationToken cancellationToken)
        {
            var birthCertificate = _dbContext.BirthCertificates.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (birthCertificate != null)
            {
                throw new Exception("The birth certificate does not exists");
            }
            birthCertificate.BirthDate = command.BirthDate;
            birthCertificate.BirthPlace = command.BirthPlace;
            birthCertificate.Country = command.Country;
            birthCertificate.Father = command.Father;
            birthCertificate.FirstName = command.FirstName;
            birthCertificate.RegistrationDate = command.RegistrationDate;
            birthCertificate.LastName = command.LastName;
            birthCertificate.Mother = command.Mother;
            birthCertificate.PersonalIdentificationNumber = command.PersonalIdentificationNumber;
            birthCertificate.RegistrationPlace = command.RegistrationPlace;
            birthCertificate.Series = command.Series;

            _dbContext.BirthCertificates.Update(birthCertificate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(birthCertificate.Identifier);
        }
    }
}
