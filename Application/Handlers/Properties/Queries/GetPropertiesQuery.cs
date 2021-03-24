using AutoMapper;
using GovernmentSystem.Application.Common.Mappings;
using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Domain.Entities.CityHallEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Properties.Queries
{
    public class GetPropertiesQuery : IRequest<List<PropertiesResponse>>
    {
        public string County { get; set; }
    }

    public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, List<PropertiesResponse>>
    {
        private readonly IPropertyService _propertyService;

        public GetPropertiesQueryHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public Task<List<PropertiesResponse>> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyService.GetProperties(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the public servants of serious fraud office", ex);
            }
        }
    }

    public class PropertiesResponse : IMapFrom<Property>
    {
        public string UniqueIdentifier { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Property, PropertiesResponse>()
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id));
        }
    }
}
