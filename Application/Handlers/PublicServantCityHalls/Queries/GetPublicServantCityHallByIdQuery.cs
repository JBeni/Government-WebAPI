namespace GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries
{
    public class GetPublicServantCityHallByIdQuery : IRequest<Result<PublicServantCityHallResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantCityHallByIdQueryHandler : IRequestHandler<GetPublicServantCityHallByIdQuery, Result<PublicServantCityHallResponse>>
    {
        private readonly IPublicServantCityHallService _publicServantCityHallService;

        public GetPublicServantCityHallByIdQueryHandler(IPublicServantCityHallService publicServantCityHallService)
        {
            _publicServantCityHallService = publicServantCityHallService;
        }

        public Task<Result<PublicServantCityHallResponse>> Handle(GetPublicServantCityHallByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantCityHallService.GetPublicServantCityHallById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantCityHallResponse>
                {
                    Error = $"There was an error retrieving the public servant of city hall by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
