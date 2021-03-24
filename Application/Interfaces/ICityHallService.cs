using GovernmentSystem.Application.Handlers.CityHalls.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;
using GovernmentSystem.Application.Handlers.CityHalls.Queries;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityHallService
    {
        Task<RequestResponse> CreateCityHall(CreateCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityHall(DeleteCityHallCommand command, CancellationToken cancellationToken);
        CityHallResponse GetCityHallById(GetCityHallByIdQuery query);
        List<CityHallsResponse> GetCityHalls(GetCityHallsQuery query);
        Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken);
    }
}
