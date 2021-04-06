using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Queries
{
    public class GetPoliceReportProblemByIdQuery : IRequest<PoliceReportProblemResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPoliceReportProblemByIdQueryHandler : IRequestHandler<GetPoliceReportProblemByIdQuery, PoliceReportProblemResponse>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public GetPoliceReportProblemByIdQueryHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public Task<PoliceReportProblemResponse> Handle(GetPoliceReportProblemByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeReportProblemService.GetPoliceReportProblemById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the police report problem by Id", ex);
            }
        }
    }
}
