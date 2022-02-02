namespace GovernmentSystem.Application.Handlers.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public Guid AddressTypeId { get; set; }
    }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, RequestResponse>
    {
        private readonly IAddressService _addressService;

        public UpdateAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<RequestResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _addressService.UpdateAddress(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.ZipCode).NotEmpty().NotNull();
            RuleFor(v => v.Street).NotEmpty().NotNull();
            RuleFor(v => v.County).NotEmpty().NotNull();
            RuleFor(v => v.Country).NotEmpty().NotNull();
            RuleFor(v => v.AddressTypeId).NotEmpty().NotNull();
        }
    }
}
