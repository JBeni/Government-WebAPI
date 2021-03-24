using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantGPs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantGPs.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantGPService
    {
        Task<RequestResponse> CreatePublicServantGP(CreatePublicServantGPCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantGP(DeletePublicServantGPCommand command, CancellationToken cancellationToken);
        PublicServantGPByIdResponse GetPublicServantGPById(GetPublicServantGPByIdQuery query);
        List<PublicServantGPsResponse> GetPublicServantGPs(GetPublicServantGPsQuery query);
        Task<RequestResponse> UpdatePublicServantGP(UpdatePublicServantGPCommand command, CancellationToken cancellationToken);
    }
}
