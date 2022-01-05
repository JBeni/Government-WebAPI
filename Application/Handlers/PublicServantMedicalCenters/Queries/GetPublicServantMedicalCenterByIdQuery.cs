namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries
{
    public class GetPublicServantMedicalCenterByIdQuery : IRequest<PublicServantMedicalCenterResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantMedicalCenterByIdQueryHandler : IRequestHandler<GetPublicServantMedicalCenterByIdQuery, PublicServantMedicalCenterResponse>
    {
        private readonly IPublicServantMedicalCenterService _publicServantMedicalCenterService;

        public GetPublicServantMedicalCenterByIdQueryHandler(IPublicServantMedicalCenterService publicServantMedicalCenterService)
        {
            _publicServantMedicalCenterService = publicServantMedicalCenterService;
        }

        public Task<PublicServantMedicalCenterResponse> Handle(GetPublicServantMedicalCenterByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantMedicalCenterService.GetPublicServantMedicalCenterById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of medical center by Id", ex);
            }
        }
    }
}
