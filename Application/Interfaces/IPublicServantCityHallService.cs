namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantCityHallService
    {
        Task<RequestResponse> CreatePublicServantCityHall(CreatePublicServantCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantCityHall(DeletePublicServantCityHallCommand command, CancellationToken cancellationToken);
        Result<PublicServantCityHallResponse> GetPublicServantCityHallById(GetPublicServantCityHallByIdQuery query);
        Result<PublicServantCityHallResponse> GetPublicServantCityHalls(GetPublicServantCityHallsQuery query);
        Task<RequestResponse> UpdatePublicServantCityHall(UpdatePublicServantCityHallCommand command, CancellationToken cancellationToken);
    }
}
