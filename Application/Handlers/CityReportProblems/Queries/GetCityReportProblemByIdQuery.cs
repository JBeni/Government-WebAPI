namespace GovernmentSystem.Application.Handlers.CityReportProblems.Queries
{
    public class GetCityReportProblemByIdQuery : IRequest<Result<CityReportProblemResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetCityReportProblemByIdQueryHandler : IRequestHandler<GetCityReportProblemByIdQuery, Result<CityReportProblemResponse>>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public GetCityReportProblemByIdQueryHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public Task<Result<CityReportProblemResponse>> Handle(GetCityReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityReportProblemService.GetCityReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CityReportProblemResponse>
                {
                    Error = $"There was an error retrieving the report problem by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
