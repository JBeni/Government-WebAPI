using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Queries
{
    public class GetPoliceReportProblemsQuery : IRequest<List<PoliceReportProblemResponse>>
    {
    }

    public class GetPoliceReportProblemsQueryHandler : IRequestHandler<GetPoliceReportProblemsQuery, List<PoliceReportProblemResponse>>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public GetPoliceReportProblemsQueryHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public Task<List<PoliceReportProblemResponse>> Handle(GetPoliceReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeReportProblemService.GetPoliceReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the police report problems", ex);
            }
        }
    }
}
