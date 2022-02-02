namespace GovernmentSystem.Application.Handlers.CityReportProblems.Queries
{
    public class GetCityReportProblemsQuery : IRequest<Result<CityReportProblemResponse>>
    {
    }

    public class GetCityReportProblemsQueryHandler : IRequestHandler<GetCityReportProblemsQuery, Result<CityReportProblemResponse>>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public GetCityReportProblemsQueryHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public Task<Result<CityReportProblemResponse>> Handle(GetCityReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityReportProblemService.GetCityReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<CityReportProblemResponse>
                {
                    Error = $"There was an error retrieving the report problems. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
