namespace GovernmentSystem.Infrastructure.Services
{
    public class IdentityCardService : IIdentityCardService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public IdentityCardService(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<RequestResponse> CreateIdentityCard(CreateIdentityCardCommand command, CancellationToken cancellationToken)
        {
            var identityCard = _dbContext.IdentityCards.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCard != null)
            {
                throw new Exception("The identity card already exists");
            }
            var entity = new IdentityCard
            {
                DateOfExpiry = command.DateOfExpiry,
                DateOfIssue = command.DateOfIssue,
                Series = command.Series,
                Type = command.Type
            };

            _dbContext.IdentityCards.Add(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(entity.Identifier);
        }

        public async Task<RequestResponse> DeleteIdentityCard(DeleteIdentityCardCommand command, CancellationToken cancellationToken)
        {
            var identityCard = _dbContext.IdentityCards.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCard != null)
            {
                throw new Exception("The identity card does not exists");
            }

            _dbContext.IdentityCards.Remove(identityCard);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(identityCard.Identifier);
        }

        public Result<IdentityCardResponse> GetIdentityCardById(GetIdentityCardByIdQuery query)
        {
            var result = _dbContext.IdentityCards
                .Where(x => x.Identifier == query.Identifier)
                .ProjectTo<IdentityCardResponse>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new Result<IdentityCardResponse> { Successful = true, Item = result ?? new IdentityCardResponse() };
        }

        public Result<IdentityCardResponse> GetIdentityCards(GetIdentityCardsQuery query)
        {
            var result = _dbContext.IdentityCards
                .ProjectTo<IdentityCardResponse>(_mapper.ConfigurationProvider)
                .ToList();
            return new Result<IdentityCardResponse> { Successful = true, Items = result ?? new List<IdentityCardResponse>() };
        }

        public async Task<RequestResponse> UpdateIdentityCard(UpdateIdentityCardCommand command, CancellationToken cancellationToken)
        {
            var identityCard = _dbContext.IdentityCards.SingleOrDefault(x => x.Identifier == command.Identifier);
            if (identityCard != null)
            {
                throw new Exception("The identity card does not exists");
            }
            identityCard.Series = command.Series;
            identityCard.Type = command.Type;
            identityCard.DateOfIssue = command.DateOfIssue;
            identityCard.DateOfExpiry = command.DateOfExpiry;

            _dbContext.IdentityCards.Update(identityCard);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return RequestResponse.Success(identityCard.Identifier);
        }
    }
}
