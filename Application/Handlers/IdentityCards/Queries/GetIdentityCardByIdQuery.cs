using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.IdentityCards.Queries
{
    public class GetIdentityCardByIdQuery : IRequest<IdentityCardResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetIdentityCardByIdQueryHandler : IRequestHandler<GetIdentityCardByIdQuery, IdentityCardResponse>
    {
        private readonly IIdentityCardService _identityCardService;

        public GetIdentityCardByIdQueryHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public Task<IdentityCardResponse> Handle(GetIdentityCardByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _identityCardService.GetIdentityCardById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the identity card by Id", ex);
            }
        }
    }
}
