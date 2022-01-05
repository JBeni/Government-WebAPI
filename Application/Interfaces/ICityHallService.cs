namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityHallService
    {
        Task<RequestResponse> CreateCityHall(CreateCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityHall(DeleteCityHallCommand command, CancellationToken cancellationToken);
        CityHallResponse GetCityHallById(GetCityHallByIdQuery query);
        List<CityHallResponse> GetCityHalls(GetCityHallsQuery query);
        Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken);
    }
}
