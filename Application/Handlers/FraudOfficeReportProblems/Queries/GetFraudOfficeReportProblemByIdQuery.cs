namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries
{
    public class GetFraudOfficeReportProblemByIdQuery : IRequest<Result<FraudOfficeReportProblemResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetFraudOfficeReportProblemByIdQueryHandler : IRequestHandler<GetFraudOfficeReportProblemByIdQuery, Result<FraudOfficeReportProblemResponse>>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public GetFraudOfficeReportProblemByIdQueryHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public Task<Result<FraudOfficeReportProblemResponse>> Handle(GetFraudOfficeReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _fraudOfficeReportProblemService.GetFraudOfficeReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<FraudOfficeReportProblemResponse>
                {
                    Error = $"There was an error retrieving the fraud office report problem by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
