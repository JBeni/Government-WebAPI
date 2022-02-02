namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class GetCitizensQuery : IRequest<Result<CitizenResponse>>
    {
    }

    public class GetCitizensQueryHandler : IRequestHandler<GetCitizensQuery, Result<CitizenResponse>>
    {
        private readonly ICitizenService _citizenService;

        public GetCitizensQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<Result<CitizenResponse>> Handle(GetCitizensQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.GetCitizens(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenResponse>
                {
                    Error = $"There was an error retrieving the citizens. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
