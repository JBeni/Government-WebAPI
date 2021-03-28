using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.Properties.Queries
{
    public class GetPropertyByIdQuery : IRequest<PropertyResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPropertyByIdQueryHandler : IRequestHandler<GetPropertyByIdQuery, PropertyResponse>
    {
        private readonly IPropertyService _propertyService;

        public GetPropertyByIdQueryHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public Task<PropertyResponse> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyService.GetPropertyById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the property by Id", ex);
            }
        }
    }
}
