using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Commands;
using GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantCityHallService : IPublicServantCityHallService
    {
        public Task<RequestResponse> CreatePublicServantCityHall(CreatePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeletePublicServantCityHall(DeletePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public PublicServantCityHallByIdResponse GetPublicServantCityHallById(GetPublicServantCityHallByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PublicServantCityHallsResponse> GetPublicServantCityHalls(GetPublicServantCityHallsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePublicServantCityHall(UpdatePublicServantCityHallCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
