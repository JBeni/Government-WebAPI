namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenRequestService
    {
        Task<RequestResponse> CreateCitizenRequest(CreateCitizenRequestCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenRequest(DeleteCitizenRequestCommand command, CancellationToken cancellationToken);
        CitizenRequestResponse GetCitizenRequestById(GetCitizenRequestByIdQuery query);
        List<CitizenRequestResponse> GetCitizenRequests(GetCitizenRequestsQuery query);
        Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken);
    }
}
