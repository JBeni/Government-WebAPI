namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByTypeQuery : IRequest<List<AddressResponse>>
    {
        public string Type { get; set; }
    }

    public class GetAddressByTypeQueryHandler : IRequestHandler<GetAddressByTypeQuery, List<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByTypeQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<AddressResponse>> Handle(GetAddressByTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressByType(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the addresses by Type", ex);
            }
        }
    }
}
