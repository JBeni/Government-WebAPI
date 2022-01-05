namespace GovernmentSystem.Application.Handlers.AddressTypes.Queries
{
    public class GetAddressTypesQuery : IRequest<List<AddressTypeResponse>>
    {
    }

    public class GetAddressTypesQueryHandler : IRequestHandler<GetAddressTypesQuery, List<AddressTypeResponse>>
    {
        private readonly IAddressTypeService _addressTypeService;

        public GetAddressTypesQueryHandler(IAddressTypeService addressTypeService)
        {
            _addressTypeService = addressTypeService;
        }

        public Task<List<AddressTypeResponse>> Handle(GetAddressTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressTypeService.GetAddressTypes(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the address types", ex);
            }
        }
    }
}
