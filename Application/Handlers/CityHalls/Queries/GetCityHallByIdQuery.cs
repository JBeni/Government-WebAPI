namespace GovernmentSystem.Application.Handlers.CityHalls.Queries
{
    public class GetCityHallByIdQuery : IRequest<CityHallResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityHallByIdQueryHandler : IRequestHandler<GetCityHallByIdQuery, CityHallResponse>
    {
        private readonly ICityHallService _cityHallService;

        public GetCityHallByIdQueryHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public Task<CityHallResponse> Handle(GetCityHallByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallService.GetCityHallById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the city hall by Id", ex);
            }
        }
    }
}
