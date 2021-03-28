using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Properties.Queries
{
    public class GetPropertiesQuery : IRequest<List<PropertyResponse>>
    {
    }

    public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, List<PropertyResponse>>
    {
        private readonly IPropertyService _propertyService;

        public GetPropertiesQueryHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public Task<List<PropertyResponse>> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyService.GetProperties(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the properties", ex);
            }
        }
    }
}
