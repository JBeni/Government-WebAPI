using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries
{
    public class GetPublicServantSFOsQuery : IRequest<List<PublicServantSFOResponse>>
    {
    }

    public class GetPublicServantSFOsQueryHandler : IRequestHandler<GetPublicServantSFOsQuery, List<PublicServantSFOResponse>>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public GetPublicServantSFOsQueryHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public Task<List<PublicServantSFOResponse>> Handle(GetPublicServantSFOsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSFOService.GetPublicServantSFOs(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
