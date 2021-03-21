using GovernmentSystem.Application.Handlers.ReportProblems.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IReportProblemService
    {
        Task<RequestResponse> AddReportProblem(CreateReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteReportProblem(DeleteReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateReportProblem(UpdateReportProblemCommand command, CancellationToken cancellationToken);
    }
}
