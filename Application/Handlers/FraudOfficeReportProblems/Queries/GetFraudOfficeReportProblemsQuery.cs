using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries
{
    public class GetFraudOfficeReportProblemsQuery : IRequest<List<FraudOfficeReportProblemResponse>>
    {
    }

    public class GetFraudOfficeReportProblemsQueryHandler : IRequestHandler<GetFraudOfficeReportProblemsQuery, List<FraudOfficeReportProblemResponse>>
    {
        private readonly IFraudOfficeReportProblemService _fraudOfficeReportProblemService;

        public GetFraudOfficeReportProblemsQueryHandler(IFraudOfficeReportProblemService fraudOfficeReportProblemService)
        {
            _fraudOfficeReportProblemService = fraudOfficeReportProblemService;
        }

        public Task<List<FraudOfficeReportProblemResponse>> Handle(GetFraudOfficeReportProblemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _fraudOfficeReportProblemService.GetFraudOfficeReportProblems(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the fraud office report problems", ex);
            }
        }
    }
}
