namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class CreateCitizenCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }

        public Guid BirthCertificateId { get; set; }
        public Guid IdentityCardId { get; set; }
        public Guid PassportId { get; set; }
        public Guid DriverLicenseId { get; set; }
        public Guid HomeAddressId { get; set; }
        public Guid CityHallResidenceId { get; set; }
        public Guid MedicalCenterId { get; set; }
        public Guid PublicServantMedicalCenterId { get; set; }
    }

    public class CreateCitizenCommandHandler : IRequestHandler<CreateCitizenCommand, RequestResponse>
    {
        private readonly ICitizenService _citizenService;

        public CreateCitizenCommandHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public async Task<RequestResponse> Handle(CreateCitizenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _citizenService.CreateCitizen(request, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateCitizenCommandValidator : AbstractValidator<CreateCitizenCommand>
    {
        public CreateCitizenCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.Age).NotEmpty().NotNull();
            RuleFor(v => v.Gender).NotEmpty().NotNull();
            RuleFor(v => v.DateOfBirth).NotEmpty().NotNull();
            RuleFor(v => v.DateOfDeath).NotEmpty().NotNull();
            RuleFor(v => v.BirthCertificateId).NotEmpty().NotNull();
            RuleFor(v => v.IdentityCardId).NotEmpty().NotNull();
            RuleFor(v => v.PassportId).NotEmpty().NotNull();
            RuleFor(v => v.DriverLicenseId).NotEmpty().NotNull();
            RuleFor(v => v.HomeAddressId).NotEmpty().NotNull();
            RuleFor(v => v.CityHallResidenceId).NotEmpty().NotNull();
            RuleFor(v => v.MedicalCenterId).NotEmpty().NotNull();
            RuleFor(v => v.PublicServantMedicalCenterId).NotEmpty().NotNull();
        }
    }
}
