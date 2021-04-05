using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Queries;
using GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Commands;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Responses;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantPoliceStationService
    {
        Task<RequestResponse> CreatePublicServantPoliceStation(CreatePublicServantPoliceStationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantPoliceStation(DeletePublicServantPoliceStationCommand command, CancellationToken cancellationToken);
        PublicServantPoliceStationResponse GetPublicServantPoliceStationById(GetPublicServantPoliceStationByIdQuery query);
        List<PublicServantPoliceStationResponse> GetPublicServantPoliceStations(GetPublicServantPoliceStationsQuery query);
        Task<RequestResponse> UpdatePublicServantPoliceStation(UpdatePublicServantPoliceStationCommand command, CancellationToken cancellationToken);
    }
}
