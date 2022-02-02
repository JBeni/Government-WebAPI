namespace GovernmentSystem.Application.Handlers.CityPayments.Queries
{
    public class GetCityPaymentByIdQuery : IRequest<Result<CityPaymentResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityPaymentByIdQueryHandler : IRequestHandler<GetCityPaymentByIdQuery, Result<CityPaymentResponse>>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public GetCityPaymentByIdQueryHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public Task<Result<CityPaymentResponse>> Handle(GetCityPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityPaymentService.GetCityPaymentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CityPaymentResponse>
                {
                    Error = $"There was an error retrieving the city payment by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
