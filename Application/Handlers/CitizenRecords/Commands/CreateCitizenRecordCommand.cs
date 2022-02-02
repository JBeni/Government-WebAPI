namespace GovernmentSystem.Application.Handlers.CitizenRecords.Commands
{
    public class CreateCitizenRecordCommand : IRequest<RequestResponse>
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

    public class CreateCitizenRecordCommandHandler : IRequestHandler<CreateCitizenRecordCommand, RequestResponse>
    {
        private readonly ICitizenRecordService _citizenRecordService;

        public CreateCitizenRecordCommandHandler(ICitizenRecordService citizenRecordService)
        {
            _citizenRecordService = citizenRecordService;
        }

        public async Task<RequestResponse> Handle(CreateCitizenRecordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _citizenRecordService.CreateCitizenRecord(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreateCitizenRecordCommandValidator : AbstractValidator<CreateCitizenRecordCommand>
    {
        public CreateCitizenRecordCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
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
