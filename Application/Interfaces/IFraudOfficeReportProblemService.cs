namespace GovernmentSystem.Application.Interfaces
{
    public interface IFraudOfficeReportProblemService
    {
        Task<RequestResponse> CreateFraudOfficeReportProblem(CreateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteFraudOfficeReportProblem(DeleteFraudOfficeReportProblemCommand command, CancellationToken cancellationToken);
        Result<FraudOfficeReportProblemResponse> GetFraudOfficeReportProblemById(GetFraudOfficeReportProblemByIdQuery query);
        Result<FraudOfficeReportProblemResponse> GetFraudOfficeReportProblems(GetFraudOfficeReportProblemsQuery query);
        Task<RequestResponse> UpdateFraudOfficeReportProblem(UpdateFraudOfficeReportProblemCommand command, CancellationToken cancellationToken);
    }
}
