namespace GovernmentSystem.Application.Handlers.PoliceReportProblems.Commands
{
    public class CreatePoliceReportProblemCommand : IRequest<RequestResponse>
    {
        public Guid Identifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsProcessed { get; set; }
        public Guid PoliceStationId { get; set; }
    }

    public class CreatePoliceReportProblemCommandHandler : IRequestHandler<CreatePoliceReportProblemCommand, RequestResponse>
    {
        private readonly IPoliceReportProblemService _policeReportProblemService;

        public CreatePoliceReportProblemCommandHandler(IPoliceReportProblemService policeReportProblemService)
        {
            _policeReportProblemService = policeReportProblemService;
        }

        public async Task<RequestResponse> Handle(CreatePoliceReportProblemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _policeReportProblemService.CreatePoliceReportProblem(request, cancellationToken);
            }
            catch (Exception ex)
            {
                return RequestResponse.Failure(ex.Message);
            }
        }
    }

    public class CreatePoliceReportProblemCommandValidator : AbstractValidator<CreatePoliceReportProblemCommand>
    {
        public CreatePoliceReportProblemCommandValidator()
        {
            RuleFor(v => v.Identifier).Null();
            RuleFor(v => v.Title).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.IsProcessed).NotEmpty().NotNull();
            RuleFor(v => v.PoliceStationId).NotEmpty().NotNull();
        }
    }
}
