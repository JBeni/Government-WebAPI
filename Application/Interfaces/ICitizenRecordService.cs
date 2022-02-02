namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenRecordService
    {
        Task<RequestResponse> CreateCitizenRecord(CreateCitizenRecordCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenRecord(DeleteCitizenRecordCommand command, CancellationToken cancellationToken);
        Result<CitizenRecordResponse> GetCitizenRecordById(GetCitizenRecordByIdQuery query);
        Result<CitizenRecordResponse> GetCitizenRecords(GetCitizenRecordsQuery query);
        Task<RequestResponse> UpdateCitizenRecord(UpdateCitizenRecordCommand command, CancellationToken cancellationToken);
    }
}
