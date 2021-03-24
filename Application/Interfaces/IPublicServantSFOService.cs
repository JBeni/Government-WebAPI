using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantSFOService
    {
        Task<RequestResponse> CreatePublicServantSFO(CreatePublicServantSFOCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantSFO(DeletePublicServantSFOCommand command, CancellationToken cancellationToken);
        PublicServantSFOByIdResponse GetPublicServantSFOById(GetPublicServantSFOByIdQuery query);
        List<PublicServantSFOsResponse> GetPublicServantSFOs(GetPublicServantSFOsQuery query);
        Task<RequestResponse> UpdatePublicServantSFO(UpdatePublicServantSFOCommand command, CancellationToken cancellationToken);
    }
}
