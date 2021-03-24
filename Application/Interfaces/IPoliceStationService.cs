using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PoliceStations.Commands;
using GovernmentSystem.Application.Handlers.PoliceStations.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IPoliceStationService
    {
        Task<RequestResponse> CreatePoliceStation(CreatePoliceStationCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePoliceStation(DeletePoliceStationCommand command, CancellationToken cancellationToken);
        PoliceStationResponse GetPoliceStationById(GetPoliceStationByIdQuery query);
        List<PoliceStationsResponse> GetPoliceStations(GetPoliceStationsQuery query);
        Task<RequestResponse> UpdatePoliceStation(UpdatePoliceStationCommand command, CancellationToken cancellationToken);
    }
}
