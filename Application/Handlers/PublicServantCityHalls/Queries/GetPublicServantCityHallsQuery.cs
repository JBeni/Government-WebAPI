using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries
{
    public class GetPublicServantCityHallsQuery : IRequest<List<PublicServantCityHallResponse>>
    {
        public string County { get; set; }
    }

    public class GetPublicServantCityHallsQueryHandler : IRequestHandler<GetPublicServantCityHallsQuery, List<PublicServantCityHallResponse>>
    {
        private readonly IPublicServantCityHallService _publicServantCityHallService;

        public GetPublicServantCityHallsQueryHandler(IPublicServantCityHallService publicServantCityHallService)
        {
            _publicServantCityHallService = publicServantCityHallService;
        }

        public Task<List<PublicServantCityHallResponse>> Handle(GetPublicServantCityHallsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantCityHallService.GetPublicServantCityHalls(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
