namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressesQuery : IRequest<Result<AddressResponse>>
    {
    }

    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQuery, Result<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressesQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<Result<AddressResponse>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddresses(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<AddressResponse>
                {
                    Error = $"There was an error retrieving the addresses. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
