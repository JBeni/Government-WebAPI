namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenRecordService
    {
        Task<RequestResponse> CreateCitizenRecord(CreateCitizenRecordCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenRecord(DeleteCitizenRecordCommand command, CancellationToken cancellationToken);
        CitizenRecordResponse GetCitizenRecordById(GetCitizenRecordByIdQuery query);
        List<CitizenRecordResponse> GetCitizenRecords(GetCitizenRecordsQuery query);
        Task<RequestResponse> UpdateCitizenRecord(UpdateCitizenRecordCommand command, CancellationToken cancellationToken);
    }
}
