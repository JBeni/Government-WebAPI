using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPoliceStations.Queries
{
    public class GetPublicServantPoliceStationByIdQuery : IRequest<PublicServantPoliceStationResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantPoliceStationByIdQueryHandler : IRequestHandler<GetPublicServantPoliceStationByIdQuery, PublicServantPoliceStationResponse>
    {
        private readonly IPublicServantPoliceStationService _publicServantPoliceService;

        public GetPublicServantPoliceStationByIdQueryHandler(IPublicServantPoliceStationService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<PublicServantPoliceStationResponse> Handle(GetPublicServantPoliceStationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPoliceStationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of police by Id", ex);
            }
        }
    }
}
