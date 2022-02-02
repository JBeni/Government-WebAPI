namespace GovernmentSystem.Application.Handlers.Passports.Commands
{
    public class DeletePassportCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePassportsCommandHandler : IRequestHandler<DeletePassportCommand, RequestResponse>
    {
        private readonly IPassportService _passportService;

        public DeletePassportsCommandHandler(IPassportService passportService)
        {
            _passportService = passportService;
        }

        public async Task<RequestResponse> Handle(DeletePassportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _passportService.DeletePassport(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeletePassportCommandValidator : AbstractValidator<DeletePassportCommand>
    {
        public DeletePassportCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
