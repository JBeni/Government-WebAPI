namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Queries
{
    public class GetPublicServantPoliceStationsQuery : IRequest<List<PublicServantPoliceStationResponse>>
    {
    }

    public class GetPublicServantPoliceStationsQueryHandler : IRequestHandler<GetPublicServantPoliceStationsQuery, List<PublicServantPoliceStationResponse>>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public GetPublicServantPoliceStationsQueryHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<List<PublicServantPoliceStationResponse>> Handle(GetPublicServantPoliceStationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPoliceStations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of police", ex);
            }
        }
    }
}
