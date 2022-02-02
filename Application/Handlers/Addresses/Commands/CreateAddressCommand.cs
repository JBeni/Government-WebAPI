namespace GovernmentSystem.Application.Handlers.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public Guid AddressTypeId { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, RequestResponse>
    {
        private readonly IAddressService _addressService;

        public CreateAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<RequestResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _addressService.CreateAddress(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(v => v.Identifier).NotNull();
            RuleFor(v => v.ZipCode).NotEmpty().NotNull();
            RuleFor(v => v.Street).NotEmpty().NotNull();
            RuleFor(v => v.County).NotEmpty().NotNull();
            RuleFor(v => v.Country).NotEmpty().NotNull();
            RuleFor(v => v.AddressTypeId).NotEmpty().NotNull();
        }
    }
}
