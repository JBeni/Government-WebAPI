namespace GovernmentSystem.Application.Handlers.Properties.Commands
{
    public class DeletePropertyCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, RequestResponse>
    {
        private readonly IPropertyService _propertyService;

        public DeletePropertyCommandHandler(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<RequestResponse> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _propertyService.DeleteProperty(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeletePropertyCommandValidator : AbstractValidator<DeletePropertyCommand>
    {
        public DeletePropertyCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
