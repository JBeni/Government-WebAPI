namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityHallService
    {
        Task<RequestResponse> CreateCityHall(CreateCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityHall(DeleteCityHallCommand command, CancellationToken cancellationToken);
        Result<CityHallResponse> GetCityHallById(GetCityHallByIdQuery query);
        Result<CityHallResponse> GetCityHalls(GetCityHallsQuery query);
        Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken);
    }
}
