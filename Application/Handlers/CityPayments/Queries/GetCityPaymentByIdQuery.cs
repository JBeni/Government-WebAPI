using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityPayments.Queries
{
    public class GetCityPaymentByIdQuery : IRequest<CityPaymentResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityPaymentByIdQueryHandler : IRequestHandler<GetCityPaymentByIdQuery, CityPaymentResponse>
    {
        private readonly ICityPaymentService _cityPaymentService;

        public GetCityPaymentByIdQueryHandler(ICityPaymentService cityPaymentService)
        {
            _cityPaymentService = cityPaymentService;
        }

        public Task<CityPaymentResponse> Handle(GetCityPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityPaymentService.GetCityPaymentById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the city payment by Id", ex);
            }
        }
    }
}
