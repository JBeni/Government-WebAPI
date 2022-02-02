namespace GovernmentSystem.Application.Handlers.CityHalls.Queries
{
    public class GetCityHallByIdQuery : IRequest<Result<CityHallResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityHallByIdQueryHandler : IRequestHandler<GetCityHallByIdQuery, Result<CityHallResponse>>
    {
        private readonly ICityHallService _cityHallService;

        public GetCityHallByIdQueryHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public Task<Result<CityHallResponse>> Handle(GetCityHallByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallService.GetCityHallById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CityHallResponse>
                {
                    Error = $"There was an error retrieving the city hall by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
