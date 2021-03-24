using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Commands;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries;
using GovernmentSystem.Application.Responses;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
