using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries
{
    public class GetPublicServantGPsQuery : IRequest<List<PublicServantGPResponse>>
    {
    }

    public class GetPublicServantGPsQueryHandler : IRequestHandler<GetPublicServantGPsQuery, List<PublicServantGPResponse>>
    {
        private readonly IPublicServantGPService _publicServantGPService;

        public GetPublicServantGPsQueryHandler(IPublicServantGPService publicServantGPService)
        {
            _publicServantGPService = publicServantGPService;
        }

        public Task<List<PublicServantGPResponse>> Handle(GetPublicServantGPsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantGPService.GetPublicServantGPs(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of GP", ex);
            }
        }
    }
}
