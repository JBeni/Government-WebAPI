using GovernmentSystem.Application.Handlers.CityHalls.Commands;
using GovernmentSystem.Application.Common.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityHallService
    {
        Task<RequestResponse> AddCityHall(CreateCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityHall(DeleteCityHallCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> UpdateCityHall(UpdateCityHallCommand command, CancellationToken cancellationToken);
    }
}
