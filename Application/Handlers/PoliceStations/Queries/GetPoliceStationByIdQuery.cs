namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationByIdQuery : IRequest<Result<PoliceStationResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPoliceStationByIdQueryHandler : IRequestHandler<GetPoliceStationByIdQuery, Result<PoliceStationResponse>>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationByIdQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<Result<PoliceStationResponse>> Handle(GetPoliceStationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PoliceStationResponse>
                {
                    Error = $"There was an error retrieving the police station by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
