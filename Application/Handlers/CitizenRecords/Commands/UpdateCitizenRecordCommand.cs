namespace GovernmentSystem.Application.Handlers.CitizenRecords.Commands
{
    public class UpdateCitizenRecordCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string CriminalityType { get; set; }
        public DateTime DateOfIssue { get; set; }
        public string Witnesses { get; set; }
        public Guid PoliceStationId { get; set; }
        public Guid CitizenId { get; set; }
    }

    public class UpdateCitizenRecordCommandHandler : IRequestHandler<UpdateCitizenRecordCommand, RequestResponse>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public UpdateCitizenRecordCommandHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public async Task<RequestResponse> Handle(UpdateCitizenRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenRecordService.UpdateCitizenRecord(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class UpdateCitizenRecordCommandValidator : AbstractValidator<UpdateCitizenRecordCommand>
    {
        public UpdateCitizenRecordCommandValidator()
        {
            RuleFor(v => v.Identifier).NotEmpty().NotNull();
            RuleFor(v => v.Reason).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.CriminalityType).NotEmpty().NotNull();
            RuleFor(v => v.DateOfIssue).NotEmpty().NotNull();
            RuleFor(v => v.Witnesses).NotEmpty().NotNull();
            RuleFor(v => v.PoliceStationId).NotEmpty().NotNull();
            RuleFor(v => v.CitizenId).NotEmpty().NotNull();
        }
    }
}
