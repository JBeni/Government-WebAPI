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
