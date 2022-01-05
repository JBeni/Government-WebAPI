namespace GovernmentSystem.Application.Handlers.Citizens.Commands
{
    public class UpdateCitizenCommand : IRequest<RequestResponse>
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

    public class UpdateCitizenCommandHandler : IRequestHandler<UpdateCitizenCommand, RequestResponse>
    {
        private readonly ICitizenService _citizenService;

        public UpdateCitizenCommandHandler(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public async Task<RequestResponse> Handle(UpdateCitizenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenService.UpdateCitizen(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class UpdateCitizenCommandValidator : AbstractValidator<UpdateCitizenCommand>
    {
        public UpdateCitizenCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
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
