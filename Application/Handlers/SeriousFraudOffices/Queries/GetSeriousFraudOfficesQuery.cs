namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries
{
    public class GetSeriousFraudOfficesQuery : IRequest<List<SeriousFraudOfficeResponse>>
    {
    }

    public class GetSeriousFraudOfficesQueryHandler : IRequestHandler<GetSeriousFraudOfficesQuery, List<SeriousFraudOfficeResponse>>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public GetSeriousFraudOfficesQueryHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public Task<List<SeriousFraudOfficeResponse>> Handle(GetSeriousFraudOfficesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _seriousFraudOfficeService.GetSeriousFraudOffices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the serious fraud offices", ex);
            }
        }
    }
}
