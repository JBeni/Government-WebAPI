using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationsQuery : IRequest<List<PoliceStationsResponse>>
    {
        public string County { get; set; }
    }

    public class GetPoliceStationsQueryHandler : IRequestHandler<GetPoliceStationsQuery, List<PoliceStationsResponse>>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationsQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<List<PoliceStationsResponse>> Handle(GetPoliceStationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStations(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PoliceStationsResponse : IMapFrom<PoliceStation>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<PoliceStation, PoliceStationsResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
