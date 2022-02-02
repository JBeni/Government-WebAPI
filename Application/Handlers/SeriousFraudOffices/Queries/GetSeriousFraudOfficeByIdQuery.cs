namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries
{
    public class GetSeriousFraudOfficeByIdQuery : IRequest<Result<SeriousFraudOfficeResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetSeriousFraudOfficeByIdQueryHandler : IRequestHandler<GetSeriousFraudOfficeByIdQuery, Result<SeriousFraudOfficeResponse>>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public GetSeriousFraudOfficeByIdQueryHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public Task<Result<SeriousFraudOfficeResponse>> Handle(GetSeriousFraudOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _seriousFraudOfficeService.GetSeriousFraudOfficeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<SeriousFraudOfficeResponse>
                {
                    Error = $"There was an error retrieving the serious fraud office by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
