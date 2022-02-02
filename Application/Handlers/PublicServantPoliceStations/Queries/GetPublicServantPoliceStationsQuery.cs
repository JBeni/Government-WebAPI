namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Queries
{
    public class GetPublicServantPoliceStationsQuery : IRequest<Result<PublicServantPoliceStationResponse>>
    {
    }

    public class GetPublicServantPoliceStationsQueryHandler : IRequestHandler<GetPublicServantPoliceStationsQuery, Result<PublicServantPoliceStationResponse>>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public GetPublicServantPoliceStationsQueryHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<Result<PublicServantPoliceStationResponse>> Handle(GetPublicServantPoliceStationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPoliceStations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantPoliceStationResponse>
                {
                    Error = $"There was an error retrieving the public servants of police. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
