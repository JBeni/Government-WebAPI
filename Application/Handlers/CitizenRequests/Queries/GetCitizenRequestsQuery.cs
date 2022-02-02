namespace GovernmentSystem.Application.Handlers.CitizenRequests.Queries
{
    public class GetCitizenRequestsQuery : IRequest<Result<CitizenRequestResponse>>
    {
    }

    public class GetCitizenRequestsQueryHandler : IRequestHandler<GetCitizenRequestsQuery, Result<CitizenRequestResponse>>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public GetCitizenRequestsQueryHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public Task<Result<CitizenRequestResponse>> Handle(GetCitizenRequestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRequestService.GetCitizenRequests(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenRequestResponse>
                {
                    Error = $"There was an error retrieving the citizen requests. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
