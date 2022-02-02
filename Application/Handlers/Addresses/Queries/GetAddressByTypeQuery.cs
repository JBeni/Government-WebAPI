namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByTypeQuery : IRequest<Result<AddressResponse>>
    {
        public string Type { get; set; }
    }

    public class GetAddressByTypeQueryHandler : IRequestHandler<GetAddressByTypeQuery, Result<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByTypeQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<Result<AddressResponse>> Handle(GetAddressByTypeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressByType(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<AddressResponse>
                {
                    Error = $"There was an error retrieving the addresses by Type. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
