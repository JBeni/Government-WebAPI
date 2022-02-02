namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalCenterProcedureService
    {
        Task<RequestResponse> CreateMedicalCenterProcedure(CreateMedicalCenterProcedureCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalCenterProcedure(DeleteMedicalCenterProcedureCommand command, CancellationToken cancellationToken);
        Result<MedicalCenterProcedureResponse> GetMedicalCenterProcedureById(GetMedicalCenterProcedureByIdQuery query);
        Result<MedicalCenterProcedureResponse> GetMedicalCenterProcedures(GetMedicalCenterProceduresQuery query);
        Task<RequestResponse> UpdateMedicalCenterProcedure(UpdateMedicalCenterProcedureCommand command, CancellationToken cancellationToken);
    }
}
