namespace GovernmentSystem.Application.Handlers.DriverLicenses.Commands
{
    public class CreateDriverLicenseCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string LicenseNumber { get; set; }
    }

    public class CreateDriverLicenseCommandHandler : IRequestHandler<CreateDriverLicenseCommand, RequestResponse>
    {
        private readonly IDriverLicenseService _driverLicenseService;

        public CreateDriverLicenseCommandHandler(IDriverLicenseService driverLicenseService)
        {
            _driverLicenseService = driverLicenseService;
        }

        public async Task<RequestResponse> Handle(CreateDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _driverLicenseService.CreateDriverLicense(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateDriverLicenseCommandValidator : AbstractValidator<CreateDriverLicenseCommand>
    {
        public CreateDriverLicenseCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.LicenseNumber).NotEmpty().NotNull();
        }
    }
}
