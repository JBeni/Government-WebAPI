using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantGPs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantGPs.Queries;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantGPService : IPublicServantGPService
    {
        public Task<RequestResponse> CreatePublicServantGP(CreatePublicServantGPCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeletePublicServantGP(DeletePublicServantGPCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public PublicServantGPResponse GetPublicServantGPById(GetPublicServantGPByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PublicServantGPResponse> GetPublicServantGPs(GetPublicServantGPsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePublicServantGP(UpdatePublicServantGPCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
