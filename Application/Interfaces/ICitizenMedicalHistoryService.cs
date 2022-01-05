namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenMedicalHistoryService
    {
        Task<RequestResponse> CreateCitizenMedicalHistory(CreateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenMedicalHistory(DeleteCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
        CitizenMedicalHistoryResponse GetCitizenMedicalHistoryById(GetCitizenMedicalHistoryByIdQuery query);
        List<CitizenMedicalHistoryResponse> GetCitizenMedicalHistories(GetCitizenMedicalHistoriesQuery query);
        Task<RequestResponse> UpdateCitizenMedicalHistory(UpdateCitizenMedicalHistoryCommand command, CancellationToken cancellationToken);
    }
}
