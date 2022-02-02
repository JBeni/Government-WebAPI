namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationsQuery : IRequest<Result<PoliceStationResponse>>
    {
    }

    public class GetPoliceStationsQueryHandler : IRequestHandler<GetPoliceStationsQuery, Result<PoliceStationResponse>>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationsQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<Result<PoliceStationResponse>> Handle(GetPoliceStationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PoliceStationResponse>
                {
                    Error = $"There was an error retrieving the police stations. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
