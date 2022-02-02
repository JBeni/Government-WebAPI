namespace GovernmentSystem.Application.Handlers.PropertyTypes.Queries
{
    public class GetPropertyTypeByIdQuery : IRequest<Result<PropertyTypeResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPropertyTypeByIdQueryHandler : IRequestHandler<GetPropertyTypeByIdQuery, Result<PropertyTypeResponse>>
    {
        private readonly IPropertyTypeService _propertyTypeService;

        public GetPropertyTypeByIdQueryHandler(IPropertyTypeService propertyTypeService)
        {
            _propertyTypeService = propertyTypeService;
        }

        public Task<Result<PropertyTypeResponse>> Handle(GetPropertyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyTypeService.GetPropertyTypeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PropertyTypeResponse>
                {
                    Error = $"There was an error retrieving the property type by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
