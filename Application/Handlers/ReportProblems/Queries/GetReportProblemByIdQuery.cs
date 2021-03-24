using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Queries
{
    public class GetReportProblemByIdQuery : IRequest<ReportProblemResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetReportProblemByIdQueryHandler : IRequestHandler<GetReportProblemByIdQuery, ReportProblemResponse>
    {
        private readonly IReportProblemService _reportProblemService;

        public GetReportProblemByIdQueryHandler(IReportProblemService reportProblemService)
        {
            _reportProblemService = reportProblemService;
        }

        public Task<ReportProblemResponse> Handle(GetReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _reportProblemService.GetReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problem by Id", ex);
            }
        }
    }
}
