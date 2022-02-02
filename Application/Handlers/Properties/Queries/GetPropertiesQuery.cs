namespace GovernmentSystem.Application.Handlers.Properties.Queries
{
    public class GetPropertiesQuery : IRequest<Result<PropertyResponse>>
    {
    }

    public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, Result<PropertyResponse>>
    {
        private readonly IPropertyService _propertyService;

        public GetPropertiesQueryHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public Task<Result<PropertyResponse>> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _propertyService.GetProperties(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<PropertyResponse>
                {
                    Error = $"There was an error retrieving the properties. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
