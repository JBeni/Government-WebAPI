namespace GovernmentSystem.Application.Handlers.MedicalCenters.Queries
{
    public class GetMedicalCenterByIdQuery : IRequest<MedicalCenterResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetMedicalCenterByIdQueryHandler : IRequestHandler<GetMedicalCenterByIdQuery, MedicalCenterResponse>
    {
        private readonly IMedicalCenterService _medicalCenterService;

        public GetMedicalCenterByIdQueryHandler(IMedicalCenterService medicalCenterService)
        {
            _medicalCenterService = medicalCenterService;
        }

        public Task<MedicalCenterResponse> Handle(GetMedicalCenterByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _medicalCenterService.GetMedicalCenterById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the medical center by Id", ex);
            }
        }
    }
}
