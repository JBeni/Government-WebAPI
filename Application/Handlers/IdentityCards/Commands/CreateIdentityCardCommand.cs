namespace GovernmentSystem.Application.Handlers.IdentityCards.Commands
{
    public class CreateIdentityCardCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Series { get; set; }
        public string Type { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
    }

    public class CreateIdentityCardCommandHandler : IRequestHandler<CreateIdentityCardCommand, RequestResponse>
    {
        private readonly IIdentityCardService _identityCardService;

        public CreateIdentityCardCommandHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public async Task<RequestResponse> Handle(CreateIdentityCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardService.CreateIdentityCard(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class CreateIdentityCardCommandValidator : AbstractValidator<CreateIdentityCardCommand>
    {
        public CreateIdentityCardCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Series).NotEmpty().NotNull();
            RuleFor(v => v.Type).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.DateOfExpiry).NotEmpty().NotNull();
        }
    }
}
