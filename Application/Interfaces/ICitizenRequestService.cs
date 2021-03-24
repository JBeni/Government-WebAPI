using GovernmentSystem.Application.Handlers.CitizenRequests.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CitizenRequests.Queries;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenRequestService
    {
        Task<RequestResponse> CreateCitizenRequest(CreateCitizenRequestCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenRequest(DeleteCitizenRequestCommand command, CancellationToken cancellationToken);
        CitizenRequestResponse GetCitizenRequestById(GetCitizenRequestByIdQuery query);
        List<CitizenRequestsResponse> GetCitizenRequests(GetCitizenRequestsQuery query);
        Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken);
    }
}
