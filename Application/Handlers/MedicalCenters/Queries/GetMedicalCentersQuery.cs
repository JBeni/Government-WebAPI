namespace GovernmentSystem.Application.Handlers.MedicalCenters.Queries
{
    public class GetMedicalCentersQuery : IRequest<Result<MedicalCenterResponse>>
    {
    }

    public class GetMedicalCentersQueryHandler : IRequestHandler<GetMedicalCentersQuery, Result<MedicalCenterResponse>>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public GetMedicalCentersQueryHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public Task<Result<MedicalCenterResponse>> Handle(GetMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterService.GetMedicalCenters(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalCenterResponse>
                {
                    Error = $"There was an error retrieving the medical centers. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
