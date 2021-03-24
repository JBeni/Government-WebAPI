﻿using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHalls.Queries
{
    public class GetCityHallsQuery : IRequest<List<CityHallsResponse>>
    {
        public string County { get; set; }
    }

    public class GetCityHallsQueryHandler : IRequestHandler<GetCityHallsQuery, List<CityHallsResponse>>
    {
        private readonly ICityHallService _cityHallService;

        public GetCityHallsQueryHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public Task<List<CityHallsResponse>> Handle(GetCityHallsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallService.GetCityHalls(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class CityHallsResponse : IMapFrom<CityHall>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CityHall, CityHallsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
