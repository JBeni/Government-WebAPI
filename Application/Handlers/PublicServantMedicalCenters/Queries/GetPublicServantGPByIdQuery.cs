using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantMedicalCenters.Queries
{
    public class GetPublicServantGPByIdQuery : IRequest<PublicServantGPResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantGPByIdQueryHandler : IRequestHandler<GetPublicServantGPByIdQuery, PublicServantGPResponse>
    {
        private readonly IPublicServantGPService _publicServantGPService;

        public GetPublicServantGPByIdQueryHandler(IPublicServantGPService publicServantGPService)
        {
            _publicServantGPService = publicServantGPService;
        }

        public Task<PublicServantGPResponse> Handle(GetPublicServantGPByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantGPService.GetPublicServantGPById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of GP by Id", ex);
            }
        }
    }
}
