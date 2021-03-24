using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.ReportProblems.Queries
{
    public class GetReportProblemsQuery : IRequest<List<ReportProblemResponse>>
    {
    }

    public class GetReportProblemsQueryHandler : IRequestHandler<GetReportProblemsQuery, List<ReportProblemResponse>>
    {
        private readonly IReportProblemService _reportProblemservice;

        public GetReportProblemsQueryHandler(IReportProblemService reportProblemService)
        {
            _reportProblemservice = reportProblemService;
        }

        public Task<List<ReportProblemResponse>> Handle(GetReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _reportProblemservice.GetReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the report problems", ex);
            }
        }
    }
}
