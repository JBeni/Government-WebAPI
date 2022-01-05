namespace GovernmentSystem.Application.Handlers.IdentityCards.Queries
{
    public class GetIdentityCardsQuery : IRequest<List<IdentityCardResponse>>
    {
    }

    public class GetIdentityCardsQueryHandler : IRequestHandler<GetIdentityCardsQuery, List<IdentityCardResponse>>
    {
        private readonly IIdentityCardService _identityCardService;

        public GetIdentityCardsQueryHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public Task<List<IdentityCardResponse>> Handle(GetIdentityCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardService.GetIdentityCards(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the identity cards", ex);
            }
        }
    }
}
