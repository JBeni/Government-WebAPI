namespace GovernmentSystem.Application.Handlers.AddressTypes.Queries
{
    public class GetAddressTypesQuery : IRequest<Result<AddressTypeResponse>>
    {
    }

    public class GetAddressTypesQueryHandler : IRequestHandler<GetAddressTypesQuery, Result<AddressTypeResponse>>
    {
        private readonly IAddressTypeService _addressTypeService;

        public GetAddressTypesQueryHandler(IAddressTypeService addressTypeService)
        {
            _addressTypeService = addressTypeService;
        }

        public Task<Result<AddressTypeResponse>> Handle(GetAddressTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressTypeService.GetAddressTypes(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<AddressTypeResponse>
                {
                    Error = $"There was an error retrieving the address types. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
