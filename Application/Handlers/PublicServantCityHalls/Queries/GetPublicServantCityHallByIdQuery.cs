﻿using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PublicServantCityHalls.Queries
{
    public class GetPublicServantCityHallByIdQuery : IRequest<PublicServantCityHallResponse>
    {
        public string County { get; set; }
    }

    public class GetPublicServantCityHallByIdQueryHandler : IRequestHandler<GetPublicServantCityHallByIdQuery, PublicServantCityHallResponse>
    {
        private readonly IPublicServantCityHallService _publicServantCityHallService;

        public GetPublicServantCityHallByIdQueryHandler(IPublicServantCityHallService publicServantCityHallService)
        {
            _publicServantCityHallService = publicServantCityHallService;
        }

        public Task<PublicServantCityHallResponse> Handle(GetPublicServantCityHallByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _publicServantCityHallService.GetPublicServantCityHallById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }
}
