using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantSFOService : IPublicServantSFOService
    {
        public Task<RequestResponse> CreatePublicServantSFO(CreatePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeletePublicServantSFO(DeletePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public PublicServantSFOResponse GetPublicServantSFOById(GetPublicServantSFOByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PublicServantSFOResponse> GetPublicServantSFOs(GetPublicServantSFOsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePublicServantSFO(UpdatePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
