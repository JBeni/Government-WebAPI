namespace GovernmentSystem.Application.Interfaces
{
    public interface IPassportService
    {
        Task<RequestResponse> CreatePassport(CreatePassportCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePassport(DeletePassportCommand command, CancellationToken cancellationToken);
        Result<PassportResponse> GetPassportById(GetPassportByIdQuery query);
        Result<PassportResponse> GetPassports(GetPassportsQuery query);
        Task<RequestResponse> UpdatePassport(UpdatePassportCommand command, CancellationToken cancellationToken);
    }
}
