namespace GovernmentSystem.Application.Handlers.CityPayments.Queries
{
    public class GetCityPaymentsQuery : IRequest<Result<CityPaymentResponse>>
    {
    }

    public class GetCityPaymentsQueryHandler : IRequestHandler<GetCityPaymentsQuery, Result<CityPaymentResponse>>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public GetCityPaymentsQueryHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public Task<Result<CityPaymentResponse>> Handle(GetCityPaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityPaymentService.GetCityPayments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CityPaymentResponse>
                {
                    Error = $"There was an error retrieving the city payments. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
