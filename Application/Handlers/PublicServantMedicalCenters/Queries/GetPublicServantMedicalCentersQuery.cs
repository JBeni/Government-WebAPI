namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries
{
    public class GetPublicServantMedicalCentersQuery : IRequest<Result<PublicServantMedicalCenterResponse>>
    {
    }

    public class GetPublicServantMedicalCentersQueryHandler : IRequestHandler<GetPublicServantMedicalCentersQuery, Result<PublicServantMedicalCenterResponse>>
    {
        private readonly IPublicServantMedicalCenterService _publicServantMedicalCenterService;

        public GetPublicServantMedicalCentersQueryHandler(IPublicServantMedicalCenterService publicServantMedicalCenterService)
        {
            _publicServantMedicalCenterService = publicServantMedicalCenterService;
        }

        public Task<Result<PublicServantMedicalCenterResponse>> Handle(GetPublicServantMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantMedicalCenterService.GetPublicServantMedicalCenters(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantMedicalCenterResponse>
                {
                    Error = $"There was an error retrieving the public servants of medical center. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
