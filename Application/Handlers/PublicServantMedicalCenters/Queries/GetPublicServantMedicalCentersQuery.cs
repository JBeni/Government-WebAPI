using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries
{
    public class GetPublicServantMedicalCentersQuery : IRequest<List<PublicServantMedicalCenterResponse>>
    {
    }

    public class GetPublicServantMedicalCentersQueryHandler : IRequestHandler<GetPublicServantMedicalCentersQuery, List<PublicServantMedicalCenterResponse>>
    {
        private readonly IPublicServantMedicalCenterService _publicServantMedicalCenterService;

        public GetPublicServantMedicalCentersQueryHandler(IPublicServantMedicalCenterService publicServantMedicalCenterService)
        {
            _publicServantMedicalCenterService = publicServantMedicalCenterService;
        }

        public Task<List<PublicServantMedicalCenterResponse>> Handle(GetPublicServantMedicalCentersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantMedicalCenterService.GetPublicServantMedicalCenters(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of medical center", ex);
            }
        }
    }
}
