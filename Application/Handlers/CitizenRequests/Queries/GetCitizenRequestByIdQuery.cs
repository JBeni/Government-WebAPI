namespace GovernmentSystem.Application.Handlers.CitizenRequests.Queries
{
    public class GetCitizenRequestByIdQuery : IRequest<Result<CitizenRequestResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenRequestByIdQueryHandler : IRequestHandler<GetCitizenRequestByIdQuery, Result<CitizenRequestResponse>>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public GetCitizenRequestByIdQueryHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public Task<Result<CitizenRequestResponse>> Handle(GetCitizenRequestByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenRequestService.GetCitizenRequestById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenRequestResponse>
                {
                    Error = $"There was an error retrieving the citizen request by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
