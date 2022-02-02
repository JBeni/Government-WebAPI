namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries
{
    public class GetPublicServantMedicalCenterByIdQuery : IRequest<Result<PublicServantMedicalCenterResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantMedicalCenterByIdQueryHandler : IRequestHandler<GetPublicServantMedicalCenterByIdQuery, Result<PublicServantMedicalCenterResponse>>
    {
        private readonly IPublicServantMedicalCenterService _publicServantMedicalCenterService;

        public GetPublicServantMedicalCenterByIdQueryHandler(IPublicServantMedicalCenterService publicServantMedicalCenterService)
        {
            _publicServantMedicalCenterService = publicServantMedicalCenterService;
        }

        public Task<Result<PublicServantMedicalCenterResponse>> Handle(GetPublicServantMedicalCenterByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantMedicalCenterService.GetPublicServantMedicalCenterById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantMedicalCenterResponse>
                {
                    Error = $"There was an error retrieving the public servant of medical center by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
