﻿using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Commands;
using GovernmentSystem.Application.Handlers.PublicServantSFOs.Queries;
using GovernmentSystem.Application.Interfaces;
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

        public PublicServantSFOByIdResponse GetPublicServantSFOById(GetPublicServantSFOByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PublicServantSFOsResponse> GetPublicServantSFOs(GetPublicServantSFOsQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePublicServantSFO(UpdatePublicServantSFOCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}