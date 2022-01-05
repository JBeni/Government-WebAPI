namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByIdQuery : IRequest<AddressResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressResponse>
    {
        private readonly IAddressService _addressService;

        public GetAddressByIdQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<AddressResponse> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the address by Id", ex);
            }
        }
    }
}
