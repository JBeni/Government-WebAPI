namespace GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries
{
    public class GetPublicServantCityHallsQuery : IRequest<Result<PublicServantCityHallResponse>>
    {
    }

    public class GetPublicServantCityHallsQueryHandler : IRequestHandler<GetPublicServantCityHallsQuery, Result<PublicServantCityHallResponse>>
    {
        private readonly IPublicServantCityHallService _publicServantCityHallService;

        public GetPublicServantCityHallsQueryHandler(IPublicServantCityHallService publicServantCityHallService)
        {
            _publicServantCityHallService = publicServantCityHallService;
        }

        public Task<Result<PublicServantCityHallResponse>> Handle(GetPublicServantCityHallsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantCityHallService.GetPublicServantCityHalls(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantCityHallResponse>
                {
                    Error = $"There was an error retrieving the public servants of city hall. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
