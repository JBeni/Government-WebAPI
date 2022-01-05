namespace GovernmentSystem.Application.Handlers.Passports.Commands
{
    public class CreatePassportCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public long PassportNumber { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class CreatePassportsCommandHandler : IRequestHandler<CreatePassportCommand, RequestResponse>
    {
        private readonly IPassportService _passportService;

        public CreatePassportsCommandHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public async Task<RequestResponse> Handle(CreatePassportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _passportService.CreatePassport(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreatePassportCommandValidator : AbstractValidator<CreatePassportCommand>
    {
        public CreatePassportCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.PassportNumber).NotEmpty().NotNull();
            RuleFor(v => v.Type).NotEmpty().NotNull();
            RuleFor(v => v.Country).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}
