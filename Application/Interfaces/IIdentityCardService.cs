namespace GovernmentSystem.Application.Interfaces
{
    public interface IIdentityCardService
    {
        Task<RequestResponse> CreateIdentityCard(CreateIdentityCardCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteIdentityCard(DeleteIdentityCardCommand command, CancellationToken cancellationToken);
        IdentityCardResponse GetIdentityCardById(GetIdentityCardByIdQuery query);
        List<IdentityCardResponse> GetIdentityCards(GetIdentityCardsQuery query);
        Task<RequestResponse> UpdateIdentityCard(UpdateIdentityCardCommand command, CancellationToken cancellationToken);
    }
}
