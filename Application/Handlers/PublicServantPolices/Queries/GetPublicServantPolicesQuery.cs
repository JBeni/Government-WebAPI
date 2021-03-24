using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Queries
{
    public class GetPublicServantPolicesQuery : IRequest<List<PublicServantPoliceResponse>>
    {
        public string County { get; set; }
    }

    public class GetPublicServantPolicesQueryHandler : IRequestHandler<GetPublicServantPolicesQuery, List<PublicServantPoliceResponse>>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public GetPublicServantPolicesQueryHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<List<PublicServantPoliceResponse>> Handle(GetPublicServantPolicesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPolices(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of police", ex);
            }
        }
    }
}
