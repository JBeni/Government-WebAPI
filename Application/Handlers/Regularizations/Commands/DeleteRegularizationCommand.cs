namespace GovernmentSystem.Application.Handlers.Regularizations.Commands
{
    public class DeleteRegularizationCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteRegularizationCommandHandler : IRequestHandler<DeleteRegularizationCommand, RequestResponse>
    {
        private readonly IRegularizationService _regularizationService;

        public DeleteRegularizationCommandHandler(IRegularizationService regularizationService)
        {
            _regularizationService = regularizationService;
        }

        public async Task<RequestResponse> Handle(DeleteRegularizationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _regularizationService.DeleteRegularization(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteRegularizationCommandValidator : AbstractValidator<DeleteRegularizationCommand>
    {
        public DeleteRegularizationCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
