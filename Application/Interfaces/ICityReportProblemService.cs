using GovernmentSystem.Application.Handlers.CityReportProblems.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CityReportProblems.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityReportProblemService
    {
        Task<RequestResponse> CreateCityReportProblem(CreateCityReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityReportProblem(DeleteCityReportProblemCommand command, CancellationToken cancellationToken);
        CityReportProblemResponse GetCityReportProblemById(GetCityReportProblemByIdQuery query);
        List<CityReportProblemResponse> GetCityReportProblems(GetCityReportProblemsQuery query);
        Task<RequestResponse> UpdateCityReportProblem(UpdateCityReportProblemCommand command, CancellationToken cancellationToken);
    }
}
