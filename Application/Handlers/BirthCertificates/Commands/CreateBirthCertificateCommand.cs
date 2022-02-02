namespace GovernmentSystem.Application.Handlers.BirthCertificates.Commands
{
    public class CreateBirthCertificateCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string PersonalIdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Country { get; set; }
        public string Series { get; set; }
        public string Mother { get; set; }
        public string Father { get; set; }
        public string RegistrationPlace { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class CreateBirthCertificateCommandHandler : IRequestHandler<CreateBirthCertificateCommand, RequestResponse>
    {
        private readonly IBirthCertificateService _birthCertificateService;

        public CreateBirthCertificateCommandHandler(IBirthCertificateService birthCertificateService)
        {
            _birthCertificateService = birthCertificateService;
        }

        public async Task<RequestResponse> Handle(CreateBirthCertificateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _birthCertificateService.CreateBirthCertificate(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateBirthCertificateCommandValidator : AbstractValidator<CreateBirthCertificateCommand>
    {
        public CreateBirthCertificateCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.PersonalIdentificationNumber).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.BirthDate).NotEmpty().NotNull();
            RuleFor(v => v.BirthPlace).NotEmpty().NotNull();
            RuleFor(v => v.Country).NotEmpty().NotNull();
            RuleFor(v => v.Series).NotEmpty().NotNull();
            RuleFor(v => v.Mother).NotEmpty().NotNull();
            RuleFor(v => v.Father).NotEmpty().NotNull();
            RuleFor(v => v.RegistrationPlace).NotEmpty().NotNull();
            RuleFor(v => v.RegistrationDate).NotEmpty().NotNull();
        }
    }
}
