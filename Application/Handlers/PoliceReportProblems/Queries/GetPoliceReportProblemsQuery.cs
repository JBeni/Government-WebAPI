namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Queries
{
    public class GetPoliceReportProblemsQuery : IRequest<Result<PoliceReportProblemResponse>>
    {
    }

    public class GetPoliceReportProblemsQueryHandler : IRequestHandler<GetPoliceReportProblemsQuery, Result<PoliceReportProblemResponse>>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public GetPoliceReportProblemsQueryHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public Task<Result<PoliceReportProblemResponse>> Handle(GetPoliceReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeReportProblemService.GetPoliceReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PoliceReportProblemResponse>
                {
                    Error = $"There was an error retrieving the police report problems. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
