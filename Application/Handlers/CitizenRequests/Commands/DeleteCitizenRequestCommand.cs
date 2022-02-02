namespace GovernmentSystem.Application.Handlers.CitizenRequests.Commands
{
    public class DeleteCitizenRequestCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCitizenRequestCommandHandler : IRequestHandler<DeleteCitizenRequestCommand, RequestResponse>
    {
        private readonly ICitizenRequestService _citizenRequestService;

        public DeleteCitizenRequestCommandHandler(ICitizenRequestService citizenRequestService)
        {
            _citizenRequestService = citizenRequestService;
        }

        public async Task<RequestResponse> Handle(DeleteCitizenRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenRequestService.DeleteCitizenRequest(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class DeleteCitizenRequestCommandValidator : AbstractValidator<DeleteCitizenRequestCommand>
    {
        public DeleteCitizenRequestCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
