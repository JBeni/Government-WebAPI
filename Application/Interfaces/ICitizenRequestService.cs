using GovernmentSystem.Application.Handlers.CitizenRequests.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICitizenRequestService
    {
        Task<RequestResponse> AddCitizenRequest(CreateCitizenRequestCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCitizenRequest(DeleteCitizenRequestCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateCitizenRequest(UpdateCitizenRequestCommand command, CancellationToken cancellationToken);
    }
}
