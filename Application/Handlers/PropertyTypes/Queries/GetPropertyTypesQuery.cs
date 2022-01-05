namespace GovernmentSystem.Application.Handlers.PropertyTypes.Queries
{
    public class GetPropertyTypesQuery : IRequest<List<PropertyTypeResponse>>
    {
    }

    public class GetPropertyTypesQueryHandler : IRequestHandler<GetPropertyTypesQuery, List<PropertyTypeResponse>>
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public GetPropertyTypesQueryHandler(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public Task<List<PropertyTypeResponse>> Handle(GetPropertyTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyTypeService.GetPropertyTypes(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the property types", ex);
            }
        }
    }
}
