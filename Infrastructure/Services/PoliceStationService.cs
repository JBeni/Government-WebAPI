using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PoliceStations.Commands;
using GovernmentSystem.Application.Handlers.PoliceStations.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PoliceStationService : IPoliceStationService
    {
        public Task<RequestResponse> CreatePoliceStation(CreatePoliceStationCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeletePoliceStation(DeletePoliceStationCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public PoliceStationResponse GetPoliceStationById(GetPoliceStationByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PoliceStationsResponse> GetPoliceStations(GetPoliceStationsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePoliceStation(UpdatePoliceStationCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
