namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantCityHallService
    {
        Task<RequestResponse> CreatePublicServantCityHall(CreatePublicServantCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantCityHall(DeletePublicServantCityHallCommand command, CancellationToken cancellationToken);
        PublicServantCityHallResponse GetPublicServantCityHallById(GetPublicServantCityHallByIdQuery query);
        List<PublicServantCityHallResponse> GetPublicServantCityHalls(GetPublicServantCityHallsQuery query);
        Task<RequestResponse> UpdatePublicServantCityHall(UpdatePublicServantCityHallCommand command, CancellationToken cancellationToken);
    }
}
