namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityReportProblemService
    {
        Task<RequestResponse> CreateCityReportProblem(CreateCityReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityReportProblem(DeleteCityReportProblemCommand command, CancellationToken cancellationToken);
        Result<CityReportProblemResponse> GetCityReportProblemById(GetCityReportProblemByIdQuery query);
        Result<CityReportProblemResponse> GetCityReportProblems(GetCityReportProblemsQuery query);
        Task<RequestResponse> UpdateCityReportProblem(UpdateCityReportProblemCommand command, CancellationToken cancellationToken);
    }
}
