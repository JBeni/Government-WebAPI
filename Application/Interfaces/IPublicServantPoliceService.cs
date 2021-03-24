using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Queries;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantPoliceService
    {
        Task<RequestResponse> CreatePublicServantPolice(CreatePublicServantPoliceCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantPolice(DeletePublicServantPoliceCommand command, CancellationToken cancellationToken);
        PublicServantPoliceByIdResponse GetPublicServantPoliceById(GetPublicServantPoliceByIdQuery query);
        List<PublicServantPolicesResponse> GetPublicServantPolices(GetPublicServantPolicesQuery query);
        Task<RequestResponse> UpdatePublicServantPolice(UpdatePublicServantPoliceCommand command, CancellationToken cancellationToken);
    }
}
