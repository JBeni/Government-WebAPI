namespace GovernmentSystem.Application.Handlers.Properties.Queries
{
    public class GetPropertyByIdQuery : IRequest<Result<PropertyResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetPropertyByIdQueryHandler : IRequestHandler<GetPropertyByIdQuery, Result<PropertyResponse>>
    {
        private readonly IPropertyService _propertyService;

        public GetPropertyByIdQueryHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public Task<Result<PropertyResponse>> Handle(GetPropertyByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyService.GetPropertyById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PropertyResponse>
                {
                    Error = $"There was an error retrieving the property by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
