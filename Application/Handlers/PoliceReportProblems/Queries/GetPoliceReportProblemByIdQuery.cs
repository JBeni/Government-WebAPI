namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Queries
{
    public class GetPoliceReportProblemByIdQuery : IRequest<Result<PoliceReportProblemResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPoliceReportProblemByIdQueryHandler : IRequestHandler<GetPoliceReportProblemByIdQuery, Result<PoliceReportProblemResponse>>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public GetPoliceReportProblemByIdQueryHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public Task<Result<PoliceReportProblemResponse>> Handle(GetPoliceReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeReportProblemService.GetPoliceReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PoliceReportProblemResponse>
                {
                    Error = $"There was an error retrieving the police report problem by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
