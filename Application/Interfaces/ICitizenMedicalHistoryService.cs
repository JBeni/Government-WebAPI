namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenMedicalHistoryService
    {
        Task<RequestResponse> CreateCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        Result<CitizenMedicalHistoryResponse> GetCitizenMedicalHistoryById(GetCitizenMedicalHistoryByIdQuery query);
        Result<CitizenMedicalHistoryResponse> GetCitizenMedicalHistories(GetCitizenMedicalHistoriesQuery query);
        Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
    }
}
