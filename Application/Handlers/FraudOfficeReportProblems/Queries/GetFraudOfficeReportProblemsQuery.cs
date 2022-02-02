namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries
{
    public class GetFraudOfficeReportProblemsQuery : IRequest<Result<FraudOfficeReportProblemResponse>>
    {
    }

    public class GetFraudOfficeReportProblemsQueryHandler : IRequestHandler<GetFraudOfficeReportProblemsQuery, Result<FraudOfficeReportProblemResponse>>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public GetFraudOfficeReportProblemsQueryHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public Task<Result<FraudOfficeReportProblemResponse>> Handle(GetFraudOfficeReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _fraudOfficeReportProblemService.GetFraudOfficeReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<FraudOfficeReportProblemResponse>
                {
                    Error = $"There was an error retrieving the fraud office report problems. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
