namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Queries
{
    public class GetPublicServantPoliceStationByIdQuery : IRequest<Result<PublicServantPoliceStationResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantPoliceStationByIdQueryHandler : IRequestHandler<GetPublicServantPoliceStationByIdQuery, Result<PublicServantPoliceStationResponse>>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public GetPublicServantPoliceStationByIdQueryHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<Result<PublicServantPoliceStationResponse>> Handle(GetPublicServantPoliceStationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPoliceStationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PublicServantPoliceStationResponse>
                {
                    Error = $"There was an error retrieving the public servant of police by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
