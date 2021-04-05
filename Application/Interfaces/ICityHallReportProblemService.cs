using GovernmentSystem.Application.Handlers.CityHallReportProblems.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CityHallReportProblems.Queries;
using System.Collections.Generic;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityHallReportProblemService
    {
        Task<RequestResponse> CreateCityHallReportProblem(CreateCityHallReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityHallReportProblem(DeleteCityHallReportProblemCommand command, CancellationToken cancellationToken);
        CityHallReportProblemResponse GetCityHallReportProblemById(GetCityHallReportProblemByIdQuery query);
        List<CityHallReportProblemResponse> GetCityHallReportProblems(GetCityHallReportProblemsQuery query);
        Task<RequestResponse> UpdateCityHallReportProblem(UpdateCityHallReportProblemCommand command, CancellationToken cancellationToken);
    }
}
