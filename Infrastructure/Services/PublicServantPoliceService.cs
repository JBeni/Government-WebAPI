﻿using GovernmentSystem.Application.Common.Models;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Commands;
using GovernmentSystem.Application.Handlers.PublicServantPolices.Queries;
using GovernmentSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Infrastructure.Services
{
    public class PublicServantPoliceService : IPublicServantPoliceService
    {
        public Task<RequestResponse> CreatePublicServantPolice(CreatePublicServantPoliceCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeletePublicServantPolice(DeletePublicServantPoliceCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public PublicServantPoliceByIdResponse GetPublicServantPoliceById(GetPublicServantPoliceByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public List<PublicServantPolicesResponse> GetPublicServantPolices(GetPublicServantPolicesQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdatePublicServantPolice(UpdatePublicServantPoliceCommand command, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}