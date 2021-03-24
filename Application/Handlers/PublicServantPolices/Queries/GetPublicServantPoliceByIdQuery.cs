using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantPolices.Queries
{
    public class GetPublicServantPoliceByIdQuery : IRequest<PublicServantPoliceResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPublicServantPoliceByIdQueryHandler : IRequestHandler<GetPublicServantPoliceByIdQuery, PublicServantPoliceResponse>
    {
        private readonly IPublicServantPoliceService _publicServantPoliceService;

        public GetPublicServantPoliceByIdQueryHandler(IPublicServantPoliceService publicServantPoliceService)
        {
            _publicServantPoliceService = publicServantPoliceService;
        }

        public Task<PublicServantPoliceResponse> Handle(GetPublicServantPoliceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantPoliceService.GetPublicServantPoliceById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servant of police by Id", ex);
            }
        }
    }
}
