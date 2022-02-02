namespace GovernmentSystem.Application.Handlers.MedicalCenters.Queries
{
    public class GetMedicalCenterByIdQuery : IRequest<Result<MedicalCenterResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalCenterByIdQueryHandler : IRequestHandler<GetMedicalCenterByIdQuery, Result<MedicalCenterResponse>>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public GetMedicalCenterByIdQueryHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public Task<Result<MedicalCenterResponse>> Handle(GetMedicalCenterByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterService.GetMedicalCenterById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<MedicalCenterResponse>
                {
                    Error = $"There was an error retrieving the medical center by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
