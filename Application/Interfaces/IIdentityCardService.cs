namespace GovernmentSystem.Application.Interfaces
{
    public interface IIdentityCardService
    {
        Task<RequestResponse> CreateIdentityCard(CreateIdentityCardCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteIdentityCard(DeleteIdentityCardCommand command, CancellationToken cancellationToken);
        Result<IdentityCardResponse> GetIdentityCardById(GetIdentityCardByIdQuery query);
        Result<IdentityCardResponse> GetIdentityCards(GetIdentityCardsQuery query);
        Task<RequestResponse> UpdateIdentityCard(UpdateIdentityCardCommand command, CancellationToken cancellationToken);
    }
}
