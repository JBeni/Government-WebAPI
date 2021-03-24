using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationsQuery : IRequest<List<PoliceStationResponse>>
    {
        public string County { get; set; }
    }

    public class GetPoliceStationsQueryHandler : IRequestHandler<GetPoliceStationsQuery, List<PoliceStationResponse>>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationsQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<List<PoliceStationResponse>> Handle(GetPoliceStationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
