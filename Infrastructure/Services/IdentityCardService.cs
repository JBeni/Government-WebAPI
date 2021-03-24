using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.IdentityCards.Commands;
using GovernmentSystem.Application.Handlers.IdentityCards.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class IdentityCardService : IIdentityCardService
    {
        public Task<RequestResponse> CreateIdentityCard(CreateIdentityCardCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteIdentityCard(DeleteIdentityCardCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IdentityCardResponse GetIdentityCardById(GetIdentityCardByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<IdentityCardsResponse> GetIdentityCards(GetIdentityCardsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateIdentityCard(UpdateIdentityCardCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
