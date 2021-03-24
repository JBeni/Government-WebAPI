using GovernmentSystem.Application.Handlers.ReportProblems.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.ReportProblems.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IReportProblemService
    {
        Task<RequestResponse> CreateReportProblem(CreateReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteReportProblem(DeleteReportProblemCommand command, CancellationToken cancellationToken);
        ReportProblemResponse GetReportProblemById(GetReportProblemByIdQuery query);
        List<ReportProblemResponse> GetReportProblems(GetReportProblemsQuery query);
        Task<RequestResponse> UpdateReportProblem(UpdateReportProblemCommand command, CancellationToken cancellationToken);
    }
}
