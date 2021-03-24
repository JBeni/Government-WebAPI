using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.CityHalls.Queries
{
    public class GetCityHallByIdQuery : IRequest<CityHallResponse>
    {
        public string County { get; set; }
    }

    public class GetCityHallByIdQueryHandler : IRequestHandler<GetCityHallByIdQuery, CityHallResponse>
    {
        private readonly ICityHallService _cityHallService;

        public GetCityHallByIdQueryHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public Task<CityHallResponse> Handle(GetCityHallByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallService.GetCityHallById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class CityHallResponse : IMapFrom<CityHall>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<CityHall, CityHallResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
