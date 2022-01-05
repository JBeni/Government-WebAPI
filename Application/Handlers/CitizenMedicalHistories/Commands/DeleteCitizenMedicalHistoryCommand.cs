namespace GovernmentSystem.Application.Handlers.CitizenMedicalHistories.Commands
{
    public class DeleteCitizenMedicalHistoryCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
    }

    public class DeleteCitizenMedicalHistoryCommandHandler : IRequestHandler<DeleteCitizenMedicalHistoryCommand, RequestResponse>
    {
        private readonly ICitizenMedicalHistoryService _citizenMedicalHistoryService;

        public DeleteCitizenMedicalHistoryCommandHandler(ICitizenMedicalHistoryService citizenMedicalHistoryService)
        {
            _citizenMedicalHistoryService = citizenMedicalHistoryService;
        }

        public async Task<RequestResponse> Handle(DeleteCitizenMedicalHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenMedicalHistoryService.DeleteCitizenMedicalHistory(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex);
            }
        }
    }

    public class DeleteCitizenMedicalHistoryCommandValidator : AbstractValidator<DeleteCitizenMedicalHistoryCommand>
    {
        public DeleteCitizenMedicalHistoryCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
        }
    }
}
