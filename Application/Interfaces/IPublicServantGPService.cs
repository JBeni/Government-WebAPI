using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Commands;
using GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries;
using GovernmentSystem.Application.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantGPService
    {
        Task<RequestResponse> CreatePublicServantGP(CreatePublicServantGPCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantGP(DeletePublicServantGPCommand command, CancellationToken cancellationToken);
        PublicServantGPResponse GetPublicServantGPById(GetPublicServantGPByIdQuery query);
        List<PublicServantGPResponse> GetPublicServantGPs(GetPublicServantGPsQuery query);
        Task<RequestResponse> UpdatePublicServantGP(UpdatePublicServantGPCommand command, CancellationToken cancellationToken);
    }
}
