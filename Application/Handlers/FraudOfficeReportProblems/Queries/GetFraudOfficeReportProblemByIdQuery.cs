namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries
{
    public class GetFraudOfficeReportProblemByIdQuery : IRequest<FraudOfficeReportProblemResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetFraudOfficeReportProblemByIdQueryHandler : IRequestHandler<GetFraudOfficeReportProblemByIdQuery, FraudOfficeReportProblemResponse>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public GetFraudOfficeReportProblemByIdQueryHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public Task<FraudOfficeReportProblemResponse> Handle(GetFraudOfficeReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _fraudOfficeReportProblemService.GetFraudOfficeReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the fraud office report problem by Id", ex);
            }
        }
    }
}
