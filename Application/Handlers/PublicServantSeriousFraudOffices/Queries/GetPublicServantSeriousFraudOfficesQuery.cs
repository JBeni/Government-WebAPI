namespace GovernmentSystem.Application.Handlers.PublicServantSeriousFraudOffices.Queries
{
    public class GetPublicServantSeriousFraudOfficesQuery : IRequest<Result<PublicServantSeriousFraudOfficeResponse>>
    {
    }

    public class GetPublicServantSeriousFraudOfficesQueryHandler : IRequestHandler<GetPublicServantSeriousFraudOfficesQuery, Result<PublicServantSeriousFraudOfficeResponse>>
    {
        private readonly IPublicServantSeriousFraudOfficeservice _publicServantSeriousFraudOfficesService;

        public GetPublicServantSeriousFraudOfficesQueryHandler(IPublicServantSeriousFraudOfficeservice publicServantSeriousFraudOfficeService)
        {
            _publicServantSeriousFraudOfficesService = publicServantSeriousFraudOfficeService;
        }

        public Task<Result<PublicServantSeriousFraudOfficeResponse>> Handle(GetPublicServantSeriousFraudOfficesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSeriousFraudOfficesService.GetPublicServantSeriousFraudOffices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantSeriousFraudOfficeResponse>
                {
                    Error = $"There was an error retrieving the public servants of serious fraud office. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
