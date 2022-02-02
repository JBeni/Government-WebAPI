namespace GovernmentSystem.Application.Handlers.Addresses.Queries
{
    public class GetAddressByIdQuery : IRequest<Result<AddressResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, Result<AddressResponse>>
    {
        private readonly IAddressService _addressService;

        public GetAddressByIdQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<Result<AddressResponse>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressService.GetAddressById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<AddressResponse>
                {
                    Error = $"There was an error retrieving the address by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
