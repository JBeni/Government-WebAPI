using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PoliceStations.Queries
{
    public class GetPoliceStationByIdQuery : IRequest<PoliceStationResponse>
    {
        public string County { get; set; }
    }

    public class GetPoliceStationByIdQueryHandler : IRequestHandler<GetPoliceStationByIdQuery, PoliceStationResponse>
    {
        private readonly IPoliceStationService _policeStationService;

        public GetPoliceStationByIdQueryHandler(IPoliceStationService policeStationService)
        {
            _policeStationService = policeStationService;
        }

        public Task<PoliceStationResponse> Handle(GetPoliceStationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _policeStationService.GetPoliceStationById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PoliceStationResponse : IMapFrom<PoliceStation>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<PoliceStation, PoliceStationResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
