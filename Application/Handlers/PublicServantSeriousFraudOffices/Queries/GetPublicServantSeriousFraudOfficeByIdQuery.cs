namespace GovernmentSystem.Application.Handlers.PublicServantSeriousFraudOffices.Queries
{
    public class GetPublicServantSeriousFraudOfficeByIdQuery : IRequest<PublicServantSeriousFraudOfficeResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantSeriousFraudOfficeQueryHandler : IRequestHandler<GetPublicServantSeriousFraudOfficeByIdQuery, PublicServantSeriousFraudOfficeResponse>
    {
        private readonly IPublicServantSeriousFraudOfficeservice _publicServantSeriousFraudOfficesService;

        public GetPublicServantSeriousFraudOfficeQueryHandler(IPublicServantSeriousFraudOfficeservice publicServantSeriousFraudOfficeService)
        {
            _publicServantSeriousFraudOfficesService = publicServantSeriousFraudOfficeService;
        }

        public Task<PublicServantSeriousFraudOfficeResponse> Handle(GetPublicServantSeriousFraudOfficeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSeriousFraudOfficesService.GetPublicServantSeriousFraudOfficeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of serious fraud office by Id", ex);
            }
        }
    }
}
