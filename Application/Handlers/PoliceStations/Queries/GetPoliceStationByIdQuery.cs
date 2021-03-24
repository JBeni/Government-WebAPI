using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationByIdQuery : IRequest<PoliceStationResponse>
    {
        public string County { get; set; }
    }

    public class GetPoliceStationByIdQueryHandler : IRequestHandler<GetPoliceStationByIdQuery, PoliceStationResponse>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationByIdQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<PoliceStationResponse> Handle(GetPoliceStationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
