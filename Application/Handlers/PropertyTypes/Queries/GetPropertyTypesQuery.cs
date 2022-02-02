namespace GovernmentSystem.Application.Handlers.PropertyTypes.Queries
{
    public class GetPropertyTypesQuery : IRequest<Result<PropertyTypeResponse>>
    {
    }

    public class GetPropertyTypesQueryHandler : IRequestHandler<GetPropertyTypesQuery, Result<PropertyTypeResponse>>
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public GetPropertyTypesQueryHandler(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public Task<Result<PropertyTypeResponse>> Handle(GetPropertyTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyTypeService.GetPropertyTypes(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PropertyTypeResponse>
                {
                    Error = $"There was an error retrieving the property types. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
