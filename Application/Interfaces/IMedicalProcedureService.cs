namespace GovernmentSystem.Application.Interfaces
{
    public interface IMedicalProcedureService
    {
        Task<RequestResponse> CreateMedicalProcedure(CreateMedicalProcedureCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteMedicalProcedure(DeleteMedicalProcedureCommand command, CancellationToken cancellationToken);
        MedicalProcedureResponse GetMedicalProcedureById(GetMedicalProcedureByIdQuery query);
        List<MedicalProcedureResponse> GetMedicalProcedures(GetMedicalProceduresQuery query);
        Task<RequestResponse> UpdateMedicalProcedure(UpdateMedicalProcedureCommand command, CancellationToken cancellationToken);
    }
}
