namespace GovernmentSystem.Application.Handlers.SeriousFraudOffices.Queries
{
    public class GetSeriousFraudOfficeByIdQuery : IRequest<SeriousFraudOfficeResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetSeriousFraudOfficeByIdQueryHandler : IRequestHandler<GetSeriousFraudOfficeByIdQuery, SeriousFraudOfficeResponse>
    {
        private readonly ISeriousFraudOfficeService _seriousFraudOfficeService;

        public GetSeriousFraudOfficeByIdQueryHandler(ISeriousFraudOfficeService seriousFraudOfficeService)
        {
            _seriousFraudOfficeService = seriousFraudOfficeService;
        }

        public Task<SeriousFraudOfficeResponse> Handle(GetSeriousFraudOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _seriousFraudOfficeService.GetSeriousFraudOfficeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the serious fraud office by Id", ex);
            }
        }
    }
}
