namespace GovernmentSystem.Application.Handlers.Citizens.Queries
{
    public class GetCitizenByIdQuery : IRequest<Result<CitizenResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCitizenByIdQueryHandler : IRequestHandler<GetCitizenByIdQuery, Result<CitizenResponse>>
    {
        private readonly ICitizenService _citizenService;

        public GetCitizenByIdQueryHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public Task<Result<CitizenResponse>> Handle(GetCitizenByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _citizenService.GetCitizenById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CitizenResponse>
                {
                    Error = $"There was an error retrieving the citizen by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
