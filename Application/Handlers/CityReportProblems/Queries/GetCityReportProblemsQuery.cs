namespace GovernmentSystem.Application.Handlers.CityReportProblems.Queries
{
    public class GetCityReportProblemsQuery : IRequest<List<CityReportProblemResponse>>
    {
    }

    public class GetCityReportProblemsQueryHandler : IRequestHandler<GetCityReportProblemsQuery, List<CityReportProblemResponse>>
    {
        private readonly ICityReportProblemService _cityReportProblemService;

        public GetCityReportProblemsQueryHandler(ICityReportProblemService cityReportProblemService)
        {
            _cityReportProblemService = cityReportProblemService;
        }

        public Task<List<CityReportProblemResponse>> Handle(GetCityReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityReportProblemService.GetCityReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problems", ex);
            }
        }
    }
}
