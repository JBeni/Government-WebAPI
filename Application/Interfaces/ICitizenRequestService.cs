namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenRequestService
    {
        Task<RequestResponse> CreateCitizenRequest(CreateCitizenRequestCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenRequest(DeleteCitizenRequestCommand command, CancellationToken cancellationToken);
        Result<CitizenRequestResponse> GetCitizenRequestById(GetCitizenRequestByIdQuery query);
        Result<CitizenRequestResponse> GetCitizenRequests(GetCitizenRequestsQuery query);
        Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken);
    }
}
