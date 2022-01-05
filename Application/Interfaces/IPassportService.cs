namespace GovernmentSystem.Application.Interfaces
{
    public interface IPassportService
    {
        Task<RequestResponse> CreatePassport(CreatePassportCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePassport(DeletePassportCommand command, CancellationToken cancellationToken);
        PassportResponse GetPassportById(GetPassportByIdQuery query);
        List<PassportResponse> GetPassports(GetPassportsQuery query);
        Task<RequestResponse> UpdatePassport(UpdatePassportCommand command, CancellationToken cancellationToken);
    }
}
