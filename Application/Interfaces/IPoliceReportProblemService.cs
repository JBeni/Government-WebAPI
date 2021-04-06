using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PoliceReportProblems.Commands;
using GovernmentSystem.Application.Handlers.PoliceReportProblems.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPoliceReportProblemService
    {
        Task<RequestResponse> CreatePoliceReportProblem(CreatePoliceReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePoliceReportProblem(DeletePoliceReportProblemCommand command, CancellationToken cancellationToken);
        PoliceReportProblemResponse GetPoliceReportProblemById(GetPoliceReportProblemByIdQuery query);
        List<PoliceReportProblemResponse> GetPoliceReportProblems(GetPoliceReportProblemsQuery query);
        Task<RequestResponse> UpdatePoliceReportProblem(UpdatePoliceReportProblemCommand command, CancellationToken cancellationToken);
    }
}
