namespace GovernmentSystem.Application.Handlers.CityHalls.Queries
{
    public class GetCityHallsQuery : IRequest<Result<CityHallResponse>>
    {
    }

    public class GetCityHallsQueryHandler : IRequestHandler<GetCityHallsQuery, Result<CityHallResponse>>
    {
        private readonly ICityHallService _cityHallService;

        public GetCityHallsQueryHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public Task<Result<CityHallResponse>> Handle(GetCityHallsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallService.GetCityHalls(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CityHallResponse>
                {
                    Error = $"There was an error retrieving the city halls. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
