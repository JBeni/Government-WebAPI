using GovernmentSystem.Application.Interfaces;
using GovernmentSystem.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Handlers.PropertyTypes.Queries
{
    public class GetPropertyTypeByIdQuery : IRequest<PropertyTypeResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPropertyTypeByIdQueryHandler : IRequestHandler<GetPropertyTypeByIdQuery, PropertyTypeResponse>
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public GetPropertyTypeByIdQueryHandler(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public Task<PropertyTypeResponse> Handle(GetPropertyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyTypeService.GetPropertyTypeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the property type by Id", ex);
            }
        }
    }
}
