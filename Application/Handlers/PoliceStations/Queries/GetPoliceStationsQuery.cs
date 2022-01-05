namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationsQuery : IRequest<List<PoliceStationResponse>>
    {
    }

    public class GetPoliceStationsQueryHandler : IRequestHandler<GetPoliceStationsQuery, List<PoliceStationResponse>>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationsQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<List<PoliceStationResponse>> Handle(GetPoliceStationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the police stations", ex);
            }
        }
    }
}
