namespace GovernmentSystem.Application.Handlers.IdentityCards.Commands
{
    public class DeleteIdentityCardCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteIdentityCardCommandHandler : IRequestHandler<DeleteIdentityCardCommand, RequestResponse>
    {
        private readonly IIdentityCardService _identityCardService;

        public DeleteIdentityCardCommandHandler(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        public async Task<RequestResponse> Handle(DeleteIdentityCardCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _identityCardService.DeleteIdentityCard(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteIdentityCardCommandValidator : AbstractValidator<DeleteIdentityCardCommand>
    {
        public DeleteIdentityCardCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
