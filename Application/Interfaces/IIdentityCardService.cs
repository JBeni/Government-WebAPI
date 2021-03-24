using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.IdentityCards.Commands;
using GovernmentSystem.Application.Handlers.IdentityCards.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface IIdentityCardService
    {
        Task<RequestResponse> CreateIdentityCard(CreateIdentityCardCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteIdentityCard(DeleteIdentityCardCommand command, CancellationToken cancellationToken);
        IdentityCardResponse GetIdentityCardById(GetIdentityCardByIdQuery query);
        List<IdentityCardsResponse> GetIdentityCards(GetIdentityCardsQuery query);
        Task<RequestResponse> UpdateIdentityCard(UpdateIdentityCardCommand command, CancellationToken cancellationToken);
    }
}
