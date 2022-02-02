namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByCountyQuery : IRequest<Result<AddressResponse>>
    {
        public string County { get; set; }
    }

    public class GetAddressByCountyQueryHandler : IRequestHandler<GetAddressByCountyQuery, Result<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByCountyQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<Result<AddressResponse>> Handle(GetAddressByCountyQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressByCounty(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<AddressResponse>
                {
                    Error = $"There was an error retrieving the addresses by county. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
