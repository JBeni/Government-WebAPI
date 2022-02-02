namespace GovernmentSystem.Infrastructure.Services
{
    public class PassportService : IPassportService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PassportService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreatePassport(CreatePassportCommand command, CancellationToken cancellationToken)
        {
            var passport = _dbContext.Passports.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (passport != null)
            {
                throw new Exception("The passport already exists");
            }
            var entity = new Passport
            {
                Country = command.Country,
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                PassportNumber = command.PassportNumber,
                Type = command.Type
            };

            _dbContext.Passports.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeletePassport(DeletePassportCommand command, CancellationToken cancellationToken)
        {
            var passport = _dbContext.Passports.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (passport != null)
            {
                throw new Exception("The passport does not exists");
            }

            _dbContext.Passports.Remove(passport);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(passport.Identifier);
        }

        public Result<PassportResponse> GetPassportById(GetPassportByIdQuery query)
        {
            var result = _dbContext.Passports
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<PassportResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<PassportResponse> { Successful = true, Item = result ?? new PassportResponse() };
        }

        public Result<PassportResponse> GetPassports(GetPassportsQuery query)
        {
            var result = _dbContext.Passports
                .ProjectTo<PassportResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<PassportResponse> { Successful = true, Items = result ?? new List<PassportResponse>() };
        }

        public async Task<RequestResponse> UpdatePassport(UpdatePassportCommand command, CancellationToken cancellationToken)
        {
            var passport = _dbContext.Passports.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (passport != null)
            {
                throw new Exception("The passport does not exists");
            }
            passport.Country = command.Country;
            passport.DateOfExpiry = command.DateOfExpiry;
            passport.DateOfIssue = command.DateOfIssue;
            passport.PassportNumber = command.PassportNumber;
            passport.Type = command.Type;

            _dbContext.Passports.Update(passport);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(passport.Identifier);
        }
    }
}
