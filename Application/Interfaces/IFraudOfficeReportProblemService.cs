using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Queries;
using GovernmentSystem.Application.Handlers.FraudOfficeReportProblems.Commands;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IFraudOfficeReportProblemService
    {
        Task<RequestResponse> CreateFraudOfficeReportProblem(CreateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteFraudOfficeReportProblem(DeleteFraudOfficeReportProblemCommand command, CancellationToken cancellationToken);
        FraudOfficeReportProblemResponse GetFraudOfficeReportProblemById(GetFraudOfficeReportProblemByIdQuery query);
        List<FraudOfficeReportProblemResponse> GetFraudOfficeReportProblems(GetFraudOfficeReportProblemsQuery query);
        Task<RequestResponse> UpdateFraudOfficeReportProblem(UpdateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken);
    }
}
