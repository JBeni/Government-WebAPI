using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries
{
    public class GetPublicServantSFOByIdQuery : IRequest<PublicServantSFOResponse>
    {
        public string County { get; set; }
    }

    public class GetPublicServantSFOQueryHandler : IRequestHandler<GetPublicServantSFOByIdQuery, PublicServantSFOResponse>
    {
        private readonly IPublicServantSFOService _publicServantSFOService;

        public GetPublicServantSFOQueryHandler(IPublicServantSFOService publicServantSFOService)
        {
            _publicServantSFOService = publicServantSFOService;
        }

        public Task<PublicServantSFOResponse> Handle(GetPublicServantSFOByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantSFOService.GetPublicServantSFOById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of serious fraud office by Id", ex);
            }
        }
    }
}
