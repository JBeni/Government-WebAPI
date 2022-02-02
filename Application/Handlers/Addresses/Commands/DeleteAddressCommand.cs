namespace GovernmentSystem.Application.Handlers.Addresses.Commands
{
    public class DeleteAddressCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, RequestResponse>
    {
        private readonly IAddressService _addressService;

        public DeleteAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<RequestResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _addressService.DeleteAddress(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
