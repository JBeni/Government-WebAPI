namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries
{
    public class GetSeriousFraudOfficesQuery : IRequest<Result<SeriousFraudOfficeResponse>>
    {
    }

    public class GetSeriousFraudOfficesQueryHandler : IRequestHandler<GetSeriousFraudOfficesQuery, Result<SeriousFraudOfficeResponse>>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public GetSeriousFraudOfficesQueryHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public Task<Result<SeriousFraudOfficeResponse>> Handle(GetSeriousFraudOfficesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _seriousFraudOfficeService.GetSeriousFraudOffices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<SeriousFraudOfficeResponse>
                {
                    Error = $"There was an error retrieving the serious fraud offices. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
