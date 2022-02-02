namespace GovernmentSystem.Application.Handlers.AddressTypes.Queries
{
    public class GetAddressTypeByIdQuery : IRequest<Result<AddressTypeResponse>>
    {
        public Guid Identifier { get; set; }
    }

    public class GetAddressTypeByIdQueryHandler : IRequestHandler<GetAddressTypeByIdQuery, Result<AddressTypeResponse>>
    {
        private readonly IAddressTypeService _addressTypeService;

        public GetAddressTypeByIdQueryHandler(IAddressTypeService addressTypeService)
        {
            _addressTypeService = addressTypeService;
        }

        public Task<Result<AddressTypeResponse>> Handle(GetAddressTypeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _addressTypeService.GetAddressTypeById(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Result<AddressTypeResponse>
                {
                    Error = $"There was an error retrieving the address type by Id. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
