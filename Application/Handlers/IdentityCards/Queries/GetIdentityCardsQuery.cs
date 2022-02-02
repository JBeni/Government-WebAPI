namespace GovernmentSystem.Application.Handlers.IdentityCards.Queries
{
    public class GetIdentityCardsQuery : IRequest<Result<IdentityCardResponse>>
    {
    }

    public class GetIdentityCardsQueryHandler : IRequestHandler<GetIdentityCardsQuery, Result<IdentityCardResponse>>
    {
        private readonly IIdentityCardService _identityCardService;

        public GetIdentityCardsQueryHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public Task<Result<IdentityCardResponse>> Handle(GetIdentityCardsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardService.GetIdentityCards(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<IdentityCardResponse>
                {
                    Error = $"There was an error retrieving the identity cards. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
