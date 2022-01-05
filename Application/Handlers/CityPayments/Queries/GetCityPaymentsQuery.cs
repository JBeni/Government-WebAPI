namespace GovernmentSystem.Application.Handlers.CityPayments.Queries
{
    public class GetCityPaymentsQuery : IRequest<List<CityPaymentResponse>>
    {
    }

    public class GetCityPaymentsQueryHandler : IRequestHandler<GetCityPaymentsQuery, List<CityPaymentResponse>>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public GetCityPaymentsQueryHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public Task<List<CityPaymentResponse>> Handle(GetCityPaymentsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityPaymentService.GetCityPayments(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the city payments", ex);
            }
        }
    }
}
