namespace GovernmentSystem.Application.Handlers.IdentityCards.Queries
{
    public class GetIdentityCardByIdQuery : IRequest<Result<IdentityCardResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetIdentityCardByIdQueryHandler : IRequestHandler<GetIdentityCardByIdQuery, Result<IdentityCardResponse>>
    {
        private readonly IIdentityCardService _identityCardService;

        public GetIdentityCardByIdQueryHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public Task<Result<IdentityCardResponse>> Handle(GetIdentityCardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardService.GetIdentityCardById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<IdentityCardResponse>
                {
                    Error = $"There was an error retrieving the identity card by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
